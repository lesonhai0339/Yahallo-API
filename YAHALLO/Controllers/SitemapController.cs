using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml.Linq;
using YAHALLO.Infrastructure.Data;

namespace YAHALLO.Controllers
{
    [ApiController]
    public class SitemapController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private const string SiteUrl = "https://www.yahallo.online";

        public SitemapController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("sitemap.xml")]
        [Produces("application/xml")]
        [ResponseCache(Duration = 3600)]
        public async Task<IActionResult> GetSitemap(CancellationToken cancellationToken)
        {
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var urlset = new XElement(ns + "urlset");

            urlset.Add(CreateUrl(ns, SiteUrl, DateTime.UtcNow, "daily", "1.0"));
            urlset.Add(CreateUrl(ns, $"{SiteUrl}/latest", DateTime.UtcNow, "daily", "0.9"));
            urlset.Add(CreateUrl(ns, $"{SiteUrl}/popular", DateTime.UtcNow, "daily", "0.9"));
            urlset.Add(CreateUrl(ns, $"{SiteUrl}/top-manga", DateTime.UtcNow, "daily", "0.8"));
            urlset.Add(CreateUrl(ns, $"{SiteUrl}/search", null, "weekly", "0.6"));

            var mangas = await _db.MangaEntities!
                .Where(m => m.DeleteDate == null)
                .Select(m => new { m.Id, m.UpdateDate, m.CreateDate })
                .ToListAsync(cancellationToken);

            foreach (var manga in mangas)
            {
                var lastMod = manga.UpdateDate ?? manga.CreateDate;
                urlset.Add(CreateUrl(ns, $"{SiteUrl}/manga/{manga.Id}", lastMod, "weekly", "0.8"));
            }

            var chapters = await _db.ChaptersEntities!
                .Where(c => c.MangaEntity.DeleteDate == null)
                .Select(c => new { c.Id, c.MangaId, c.Index, c.CreateDate })
                .ToListAsync(cancellationToken);

            foreach (var ch in chapters)
            {
                urlset.Add(CreateUrl(ns, $"{SiteUrl}/manga/{ch.MangaId}/chapter/{ch.Id}/0", ch.CreateDate, "monthly", "0.6"));
            }

            var tags = await _db.Tags
                .Where(t => t.DeleteDate == null)
                .Select(t => new { t.Id })
                .ToListAsync(cancellationToken);

            foreach (var tag in tags)
            {
                urlset.Add(CreateUrl(ns, $"{SiteUrl}/the-loai/{tag.Id}", null, "weekly", "0.7"));
            }

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null), urlset);
            return Content(doc.ToString(), "application/xml", Encoding.UTF8);
        }

        private static XElement CreateUrl(XNamespace ns, string loc, DateTime? lastmod, string changefreq, string priority)
        {
            var url = new XElement(ns + "url",
                new XElement(ns + "loc", loc),
                new XElement(ns + "changefreq", changefreq),
                new XElement(ns + "priority", priority));

            if (lastmod.HasValue)
            {
                url.Add(new XElement(ns + "lastmod", lastmod.Value.ToString("yyyy-MM-dd")));
            }

            return url;
        }
    }
}
