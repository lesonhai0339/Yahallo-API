'use strict';
// Yahallo Manga Seed Data Scraper
// Uses: Jikan API (free MyAnimeList wrapper) + TruyenQQ
// Requires: Node.js v18+ (built-in fetch)

const fs   = require('fs');
const path = require('path');
const crypto = require('crypto');

// ── paths ──────────────────────────────────────────────────────────────────
const RES_DIR       = __dirname;
const THUMBS_DIR    = path.join(RES_DIR, 'thumbnails');
const OUTPUT_SQL    = path.join(RES_DIR, 'seed_data.sql');

if (!fs.existsSync(THUMBS_DIR)) fs.mkdirSync(THUMBS_DIR, { recursive: true });

// ── seed constants ─────────────────────────────────────────────────────────
const ADMIN_USER_ID = '00000000-0000-0000-0000-000000000001';
const ADMIN_ROLE_ID = '00000000-0000-0000-0000-000000000002';
const MOD_ROLE_ID   = '00000000-0000-0000-0000-000000000003';
const USER_ROLE_ID  = '00000000-0000-0000-0000-000000000004';
const SEED_DATE     = new Date('2026-01-01T00:00:00');

// ── helpers ────────────────────────────────────────────────────────────────
const newId = () => crypto.randomUUID();
const sleep = ms => new Promise(r => setTimeout(r, ms));

// SQL-escape a nullable string value
const sq = v => v == null ? 'NULL' : `N'${String(v).replace(/'/g, "''").replace(/[\r\n\t]+/g, ' ').trim()}'`;
const sqDate = d => `'${new Date(d).toISOString().replace('T', ' ').replace('Z', '').slice(0, 23)}'`;

// ASP.NET Core Identity v3 PBKDF2-SHA256 password hash
function hashPassword(password) {
    const saltSize = 16, keySize = 32, iterations = 100000;
    const salt = crypto.randomBytes(saltSize);
    const key  = crypto.pbkdf2Sync(password, salt, iterations, keySize, 'sha256');
    const buf  = Buffer.alloc(1 + 4 + 4 + 4 + saltSize + keySize);
    buf.writeUInt8(0x01, 0);
    buf.writeUInt32BE(1,          1);   // HMACSHA256
    buf.writeUInt32BE(iterations, 5);
    buf.writeUInt32BE(saltSize,   9);
    salt.copy(buf, 13);
    key.copy(buf,  13 + saltSize);
    return buf.toString('base64');
}

async function downloadImage(url, destPath) {
    if (!url) return false;
    try {
        const res = await fetch(url, {
            headers: { 'User-Agent': 'Mozilla/5.0', Referer: 'https://myanimelist.net' },
            signal: AbortSignal.timeout(20000),
            redirect: 'follow',
        });
        if (!res.ok) return false;
        const buf = Buffer.from(await res.arrayBuffer());
        if (buf.length < 500) return false;
        fs.writeFileSync(destPath, buf);
        return true;
    } catch { return false; }
}

// ── fetch: Jikan (MyAnimeList) ─────────────────────────────────────────────
async function fetchJikanTopManga() {
    console.log('\n[1/3] Fetching top manga from Jikan API (MyAnimeList)...');
    const items = [];
    for (let page = 1; page <= 2; page++) {
        try {
            const url = `https://api.jikan.moe/v4/top/manga?limit=20&type=manga&page=${page}`;
            const res = await fetch(url, {
                headers: { Accept: 'application/json' },
                signal: AbortSignal.timeout(25000),
            });
            if (!res.ok) { console.warn(`  Jikan p${page}: HTTP ${res.status}`); break; }
            const json = await res.json();
            items.push(...(json.data || []));
            console.log(`  Page ${page}: ${(json.data||[]).length} items`);
            if (!json.pagination?.has_next_page) break;
        } catch (e) { console.warn(`  Jikan error: ${e.message}`); break; }
        await sleep(600); // Jikan rate-limit: 3 req/s
    }
    return items;
}

// ── fetch: TruyenQQ ────────────────────────────────────────────────────────
async function fetchTruyenQQ() {
    console.log('\n[2/3] Fetching from TruyenQQ...');
    const candidates = [
        'https://truyenqqko.com/truyen-tranh/?page=1',
        'https://truyenqqko.com/danh-sach-truyen/',
        'https://truyenqqko.com/',
    ];
    for (const url of candidates) {
        try {
            const res = await fetch(url, {
                headers: {
                    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36',
                    Accept: 'text/html,application/xhtml+xml,*/*;q=0.8',
                    'Accept-Language': 'vi-VN,vi;q=0.9,en;q=0.5',
                },
                signal: AbortSignal.timeout(25000),
                redirect: 'follow',
            });
            if (res.ok) {
                const html = await res.text();
                const found = parseTruyenQQ(html, url);
                if (found.length > 0) return found;
            } else { console.warn(`  ${url} → HTTP ${res.status}`); }
        } catch (e) { console.warn(`  ${url} → ${e.message}`); }
        await sleep(1500);
    }
    return [];
}

function parseTruyenQQ(html, baseUrl) {
    const items = [];
    const seen  = new Set();

    // Helper to safe-add manga
    const add = (title, thumb, genres, status) => {
        const t = title.trim().replace(/&amp;/g, '&').replace(/&#\d+;/g, '');
        if (!t || seen.has(t.toLowerCase()) || items.length >= 15) return;
        seen.add(t.toLowerCase());
        let st = 1;
        if (/hoàn\s*thành|completed/i.test(status || '')) st = 3;
        else if (/tạm\s*ngưng|hiatus/i.test(status || '')) st = 2;
        items.push({ title: t, thumbnail: thumb || null, genres: genres || [], status: st });
    };

    // Pattern A – story-item / list-truyen blocks
    const blockRe = /<(?:div|li)[^>]+class="[^"]*(?:story-item|list-story|book-item|manga-item)[^"]*"[^>]*>([\s\S]*?)<\/(?:div|li)>/g;
    let bm;
    while ((bm = blockRe.exec(html)) !== null && items.length < 15) {
        const blk = bm[1];
        const titleM = /<a[^>]+(?:title|alt)="([^"]{2,100})"/.exec(blk)
                    || /class="[^"]*title[^"]*"[^>]*>([^<]{2,100})</.exec(blk);
        if (!titleM) continue;
        const imgM    = /<img[^>]+(?:data-original|data-src|src)="(https?:\/\/[^"]+(?:jpg|jpeg|png|webp)[^"]*)"/.exec(blk);
        const statusM = /(?:Đang tiến hành|Hoàn thành|Tạm ngưng|Completed|Ongoing)/i.exec(blk);
        const genres  = [];
        const gRe     = /href="[^"]*(?:the-loai|genre)[^"]*">([^<]+)</g;
        let gm;
        while ((gm = gRe.exec(blk)) !== null) genres.push(gm[1].trim());
        add(titleM[1], imgM?.[1], genres, statusM?.[0]);
    }

    // Pattern B – <h3 class="title"><a href="...truyen...">Title</a></h3>
    if (items.length === 0) {
        const h3Re  = /<h3[^>]*class="[^"]*title[^"]*"[^>]*>\s*<a[^>]+href="([^"]*truyen[^"]*)"[^>]*>([^<]{2,100})<\/a>/g;
        const imgRe = /<img[^>]+(?:data-original|data-src|src)="(https?:\/\/[^"]+(?:jpg|jpeg|png|webp)[^"]*)"/g;
        const imgs  = [];
        let im;
        while ((im = imgRe.exec(html)) !== null) {
            if (!im[1].includes('banner') && !im[1].includes('logo')) imgs.push(im[1]);
        }
        let idx = 0, hm;
        while ((hm = h3Re.exec(html)) !== null && items.length < 15) {
            add(hm[2], imgs[idx++], [], null);
        }
    }

    // Pattern C – generic title + image extraction
    if (items.length === 0) {
        const tRe = /<a[^>]+title="([^"]{3,80})"[^>]+href="([^"]*(?:truyen|manga|comic)[^"]*)"/g;
        const iRe = /<img[^>]+(?:data-original|data-src|src)="(https?:\/\/[^"]+(?:jpg|jpeg|png|webp)[^"]*)"/gi;
        const imgs = [];
        let m;
        while ((m = iRe.exec(html)) !== null && imgs.length < 20) {
            if (!m[1].includes('banner') && !m[1].includes('logo') && !m[1].includes('icon')) imgs.push(m[1]);
        }
        let idx2 = 0;
        while ((m = tRe.exec(html)) !== null && items.length < 15) {
            add(m[1], imgs[idx2++], [], null);
        }
    }

    console.log(`  Parsed ${items.length} manga from TruyenQQ`);
    return items;
}

// ── data mapping ───────────────────────────────────────────────────────────
function mapJikanItem(item) {
    const typeStr   = item.type || 'Manga';
    const statusStr = item.status || '';

    let mangaType = 2;  // Series
    if (typeStr === 'One-shot') mangaType = 1;
    else if (typeStr === 'Doujin') mangaType = 3;

    let country = 112; // Japan
    if (typeStr === 'Manhwa') country = 119;
    else if (typeStr === 'Manhua') country = 46;

    let status = 1; // Active/Publishing
    if (/finished|completed/i.test(statusStr))     status = 3;
    else if (/hiatus|discontinued/i.test(statusStr)) status = 2;

    const authors = (item.authors || []).map(a => {
        let name = a.name || '';
        const parts = name.split(',').map(s => s.trim());
        if (parts.length === 2) name = `${parts[1]} ${parts[0]}`;
        return name;
    }).filter(Boolean);

    const genres = [
        ...(item.genres       || []).map(g => g.name),
        ...(item.demographics || []).map(d => d.name),
        ...(item.themes       || []).map(t => t.name),
    ].filter(Boolean);

    const synopsis = (item.synopsis || '')
        .replace(/\[Written by MAL Rewrite\]/gi, '')
        .replace(/Source:\s*\w+/gi, '')
        .trim();

    return {
        malId:         item.mal_id,
        title:         item.title || '',
        titleEnglish:  item.title_english || '',
        titleJapanese: item.title_japanese || '',
        description:   synopsis || 'No description available.',
        type:          mangaType,
        status,
        country,
        level:         1, // Normal (free)
        thumbnail:     item.images?.jpg?.large_image_url || item.images?.jpg?.image_url || null,
        authors,
        genres,
        source:        'jikan_mal',
    };
}

// ── SQL generator ──────────────────────────────────────────────────────────
function buildSql(mangaList, tagMap, authorMap) {
    const lines = [];
    const pw_admin = hashPassword('Admin@123');
    const pw_user  = hashPassword('User@123');

    const hdr = (...ss) => { lines.push(''); lines.push(...ss.map(s => `-- ${s}`)); };

    lines.push(`-- ================================================================`);
    lines.push(`-- Yahallo Manga Website - Seed Data`);
    lines.push(`-- Generated : ${new Date().toISOString()}`);
    lines.push(`-- Sources   : MyAnimeList (Jikan API) + TruyenQQ`);
    lines.push(`-- Admin     : admin@yahallo.com  /  Admin@123`);
    lines.push(`-- ================================================================`);
    lines.push('');
    lines.push('USE [Yahallo]');
    lines.push('GO');
    lines.push('SET NOCOUNT ON;');
    lines.push('SET XACT_ABORT ON;');
    lines.push('BEGIN TRANSACTION;');
    lines.push('');

    // ---- Users
    hdr('USERS');
    const users = [
        { id: ADMIN_USER_ID, display: 'Admin',      first: 'Admin',   last: 'Yahallo',  email: 'admin@yahallo.com',  uname: 'admin',  pw: pw_admin, status: 1, level: 9 },
        { id: newId(),        display: 'TestUser1',  first: 'Nguyen',  last: 'Van A',    email: 'user1@yahallo.com',  uname: 'user1',  pw: pw_user,  status: 1, level: 1 },
        { id: newId(),        display: 'TestUser2',  first: 'Tran',    last: 'Thi B',    email: 'user2@yahallo.com',  uname: 'user2',  pw: pw_user,  status: 1, level: 2 },
    ];
    for (const u of users) {
        lines.push(
            `INSERT INTO [dbo].[Users]` +
            ` ([Id],[DisplayName],[FirstName],[LastName],[Email],[PhoneNumber],[EmailConfirm],[PhoneConfirmed],[UserName],[Password],[Status],[Level],[CreateDate],[IdUserCreate])` +
            ` VALUES (${sq(u.id)},${sq(u.display)},${sq(u.first)},${sq(u.last)},${sq(u.email)},NULL,1,0,${sq(u.uname)},${sq(u.pw)},${u.status},${u.level},${sqDate(SEED_DATE)},${sq(ADMIN_USER_ID)});`
        );
    }

    // ---- Roles
    hdr('ROLES');
    const roles = [
        { id: ADMIN_ROLE_ID, code: 1, name: 'Admin',     desc: 'System administrator' },
        { id: MOD_ROLE_ID,   code: 2, name: 'Moderator', desc: 'Content moderator'    },
        { id: USER_ROLE_ID,  code: 3, name: 'User',      desc: 'Regular user'         },
    ];
    for (const r of roles) {
        lines.push(
            `INSERT INTO [dbo].[Roles]` +
            ` ([Id],[RoleCode],[RoleName],[RoleDescription],[CreateDate],[IdUserCreate])` +
            ` VALUES (${sq(r.id)},${r.code},${sq(r.name)},${sq(r.desc)},${sqDate(SEED_DATE)},${sq(ADMIN_USER_ID)});`
        );
    }

    // ---- UserRole
    hdr('USER ROLES');
    lines.push(
        `INSERT INTO [dbo].[UserRole] ([UserId],[RoleId],[CreateDate],[IdUserCreate])` +
        ` VALUES (${sq(ADMIN_USER_ID)},${sq(ADMIN_ROLE_ID)},${sqDate(SEED_DATE)},${sq(ADMIN_USER_ID)});`
    );

    // ---- Tags
    hdr('TAGS (GENRES)');
    for (const [name, id] of Object.entries(tagMap)) {
        lines.push(
            `INSERT INTO [dbo].[Tag] ([Id],[Name],[Description],[CreateDate],[IdUserCreate])` +
            ` VALUES (${sq(id)},${sq(name)},${sq('Genre/theme: ' + name)},${sqDate(SEED_DATE)},${sq(ADMIN_USER_ID)});`
        );
    }

    // ---- Authors
    hdr('AUTHORS');
    for (const [name, id] of Object.entries(authorMap)) {
        lines.push(
            `INSERT INTO [dbo].[Author] ([Id],[Name],[Countries],[Depscription],[Birth],[LifeStatus],[CreateDate],[IdUserCreate])` +
            ` VALUES (${sq(id)},${sq(name)},112,${sq('Manga author/writer')},` +
            `'1980-01-01 00:00:00.000',1,${sqDate(SEED_DATE)},${sq(ADMIN_USER_ID)});`
        );
    }

    // ---- Artists  (same people, different entity)
    hdr('ARTISTS');
    const artistMap = {};
    for (const [name] of Object.entries(authorMap)) {
        const artistId = newId();
        artistMap[name] = artistId;
        lines.push(
            `INSERT INTO [dbo].[Artist] ([Id],[Name],[Countries],[Depscription],[Birth],[LifeStatus],[CreateDate],[IdUserCreate])` +
            ` VALUES (${sq(artistId)},${sq(name)},112,${sq('Manga artist/illustrator')},` +
            `'1980-01-01 00:00:00.000',1,${sqDate(SEED_DATE)},${sq(ADMIN_USER_ID)});`
        );
    }

    // ---- Per-manga data
    hdr('MANGA DATA (MangaSeason + Manga + Images + Chapters + Relations)');
    for (let i = 0; i < mangaList.length; i++) {
        const m     = mangaList[i];
        const d     = new Date(SEED_DATE.getTime() + i * 3 * 86400000);
        const sId   = newId();

        lines.push(`-- [${i + 1}] ${m.title}`);

        // MangaSeason
        lines.push(
            `INSERT INTO [dbo].[MangaSeason] ([Id],[Season],[Description],[CreateDate],[IdUserCreate])` +
            ` VALUES (${sq(sId)},1.0,${sq('Season 1')},${sqDate(d)},${sq(ADMIN_USER_ID)});`
        );

        // Manga  (UserId is nullable FK — use NULL to avoid FK_Manga_Users_UserId conflicts)
        lines.push(
            `INSERT INTO [dbo].[Manga] ([Id],[Name],[Description],[Level],[Status],[Type],[Countries],[Season],[MangaSeasonId],[UserId],[CreateDate],[IdUserCreate])` +
            ` VALUES (${sq(m.id)},${sq(m.title)},${sq(m.description || 'N/A')},` +
            `${m.level},${m.status},${m.type},${m.country},1,${sq(sId)},NULL,${sqDate(d)},${sq(ADMIN_USER_ID)});`
        );

        // Thumbnail image
        if (m.thumbnailFile) {
            const imgId  = newId();
            const base   = `Data\\Thumbnail\\${m.thumbnailFile}`;
            const cloud  = m.thumbnailUrl ? sq(m.thumbnailUrl) : 'NULL';
            lines.push(
                `INSERT INTO [dbo].[Image] ([Id],[Index],[BaseUrl],[CloudUrl],[TypeImage],[UserId],[MangaId],[CreateDate],[IdUserCreate])` +
                ` VALUES (${sq(imgId)},1,${sq(base)},${cloud},2,NULL,${sq(m.id)},${sqDate(d)},${sq(ADMIN_USER_ID)});`
            );
        }

        // MangaView
        const views = Math.floor(Math.random() * 800000) + 5000;
        lines.push(
            `INSERT INTO [dbo].[MangaView] ([MangaId],[View],[CreateDate],[IdUserCreate])` +
            ` VALUES (${sq(m.id)},${views},${sqDate(d)},${sq(ADMIN_USER_ID)});`
        );

        // Chapters  (3 stubs per manga)
        for (let ci = 1; ci <= 3; ci++) {
            const chapId   = newId();
            const chapDate = new Date(d.getTime() + ci * 86400000);
            lines.push(
                `INSERT INTO [dbo].[Chapter] ([Id],[Title],[Index],[MangaId],[CreateDate],[IdUserCreate])` +
                ` VALUES (${sq(chapId)},${sq(`Chapter ${ci}`)},${ci},${sq(m.id)},${sqDate(chapDate)},${sq(ADMIN_USER_ID)});`
            );
        }

        // MangaTag
        for (const g of (m.genres || []).slice(0, 6)) {
            if (!tagMap[g]) continue;
            lines.push(
                `INSERT INTO [dbo].[MangaTag] ([MangaId],[TagId],[CreateDate],[IdUserCreate])` +
                ` VALUES (${sq(m.id)},${sq(tagMap[g])},${sqDate(d)},${sq(ADMIN_USER_ID)});`
            );
        }

        // MangaAuthor + MangaArtist
        for (const aName of (m.authors || []).slice(0, 2)) {
            const aId = authorMap[aName];
            if (aId) {
                lines.push(
                    `INSERT INTO [dbo].[MangaAuthor] ([MangaId],[AuthorId],[CreateDate],[IdUserCreate])` +
                    ` VALUES (${sq(m.id)},${sq(aId)},${sqDate(d)},${sq(ADMIN_USER_ID)});`
                );
            }
            const rId = artistMap[aName];
            if (rId) {
                lines.push(
                    `INSERT INTO [dbo].[MangaArtist] ([MangaId],[ArtistId],[CreateDate],[IdUserCreate])` +
                    ` VALUES (${sq(m.id)},${sq(rId)},${sqDate(d)},${sq(ADMIN_USER_ID)});`
                );
            }
        }

        // AssociateNames (alternate titles)
        const altTitles = [
            [m.titleEnglish,  m.title],
            [m.titleJapanese, m.title],
        ];
        for (const [alt, orig] of altTitles) {
            if (alt && alt !== orig && alt.length > 1) {
                lines.push(
                    `INSERT INTO [dbo].[AssociateName] ([Id],[Name],[MangaId],[CreateDate],[IdUserCreate])` +
                    ` VALUES (${sq(newId())},${sq(alt)},${sq(m.id)},${sqDate(d)},${sq(ADMIN_USER_ID)});`
                );
            }
        }
    }

    lines.push('');
    lines.push('COMMIT TRANSACTION;');
    lines.push("PRINT N'Seed data inserted successfully.';");
    lines.push('GO');

    return lines.join('\n');
}

// ── main ───────────────────────────────────────────────────────────────────
async function main() {
    console.log('=== Yahallo Seed Data Generator ===');

    // 1. Jikan / MAL
    const jikanRaw = await fetchJikanTopManga();
    console.log(`  Jikan total: ${jikanRaw.length} items`);

    // 2. TruyenQQ
    const truyenRaw = await fetchTruyenQQ();

    console.log('\n[3/3] Processing data...');

    const mangaList = [];
    const tagMap    = {};   // genre name  → UUID
    const authorMap = {};   // author name → UUID
    const seenTitles = new Set();

    // Process Jikan items
    for (const raw of jikanRaw) {
        const m = mapJikanItem(raw);
        m.id = newId();
        for (const g of m.genres)   if (!tagMap[g])    tagMap[g]    = newId();
        for (const a of m.authors)  if (!authorMap[a]) authorMap[a] = newId();
        mangaList.push(m);
        seenTitles.add(m.title.toLowerCase());
    }

    // Process TruyenQQ items (skip duplicates)
    for (const raw of truyenRaw) {
        if (seenTitles.has(raw.title.toLowerCase())) continue;
        const m = {
            id:            newId(),
            title:         raw.title,
            titleEnglish:  '',
            titleJapanese: '',
            description:   'Manga from TruyenQQ.',
            type:          2,          // Series
            status:        raw.status,
            country:       119,        // Korea (manhwa common on VN aggregators)
            level:         1,
            thumbnail:     raw.thumbnail,
            thumbnailUrl:  raw.thumbnail,
            authors:       [],
            genres:        raw.genres || [],
            source:        'truyenqqko',
        };
        for (const g of m.genres) if (!tagMap[g]) tagMap[g] = newId();
        mangaList.push(m);
        seenTitles.add(m.title.toLowerCase());
    }

    console.log(`  Manga  : ${mangaList.length}`);
    console.log(`  Tags   : ${Object.keys(tagMap).length}`);
    console.log(`  Authors: ${Object.keys(authorMap).length}`);

    // 3. Download thumbnails
    console.log('\nDownloading thumbnails...');
    let ok = 0, fail = 0;
    for (const m of mangaList) {
        if (!m.thumbnail) { m.thumbnailFile = null; continue; }

        const ext      = (m.thumbnail.match(/\.(jpe?g|png|webp)/i) || ['', 'jpg'])[1].toLowerCase().replace('jpeg', 'jpg');
        const safeName = m.title.replace(/[^a-zA-Z0-9]/g, '_').slice(0, 35);
        const fname    = `${safeName}${m.malId ? '_mal' + m.malId : '_tqq' + mangaList.indexOf(m)}.${ext}`;
        const dest     = path.join(THUMBS_DIR, fname);

        if (fs.existsSync(dest)) {
            m.thumbnailFile = fname;
            ok++;
            continue;
        }

        process.stdout.write(`  ${fname.slice(0, 50).padEnd(52)}`);
        const success = await downloadImage(m.thumbnail, dest);
        if (success) {
            process.stdout.write('✓\n');
            m.thumbnailFile = fname;
            m.thumbnailUrl  = m.thumbnail;
            ok++;
        } else {
            process.stdout.write('✗\n');
            m.thumbnailFile = null;
            fail++;
        }
        await sleep(150);
    }
    console.log(`  Downloaded: ${ok}  Failed: ${fail}`);

    // 4. Generate SQL
    console.log('\nGenerating SQL seed file...');
    const sql = buildSql(mangaList, tagMap, authorMap);
    fs.writeFileSync(OUTPUT_SQL, sql, 'utf8');

    console.log('\n=== Complete ===');
    console.log(`  SQL  : ${OUTPUT_SQL}`);
    console.log(`  Imgs : ${THUMBS_DIR}  (${ok} files)`);
    console.log(`  Manga: ${mangaList.length} entries  |  Tags: ${Object.keys(tagMap).length}  |  Authors: ${Object.keys(authorMap).length}`);
    console.log(`  Admin login: admin@yahallo.com / Admin@123`);
}

main().catch(e => { console.error('\nFatal error:', e.message); process.exit(1); });
