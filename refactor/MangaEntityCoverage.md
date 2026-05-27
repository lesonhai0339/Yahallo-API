# Manga Entity Coverage Review

Current project has the core objects for a small manga site:

- `MangaEntity`
- `ChapterEntity`
- `ImageEntity`
- `MangaSeasonEntity`
- `MangaAssociateNameEntity`
- `AuthorEntity` / `ArtistEntity`
- `MangaAuthorEntity` / `MangaArtistEntity`
- `FollowEntity`
- `MangaRatingEntity`
- `MangaViewEntity`
- `CommentEntity`

That is enough for basic CRUD, upload thumbnail/pages, follow, rating, and comment.
It is not enough for a MangaDex-like catalog.

## Missing For A Strong Manga Catalog

- Localized primary titles and alternate titles.
- Localized descriptions.
- Normalized tags/genres/themes/formats with localized names.
- Publication metadata: original language, release year, demographic, content rating, last volume/chapter, publish state.
- Multiple cover arts, including volume-specific covers.
- External IDs/links to official raw, official English, AniList, MAL, MangaUpdates, etc.
- Related manga relations: sequel, prequel, spin-off, adaptation, alternate version.
- Chapter metadata: volume, decimal chapter number, translated language, readable/published timestamp.
- Chapter pages separate from general `ImageEntity`, with page index, dimensions, file hash, and storage path.
- Scanlation groups and chapter-to-group relationship.
- User library/reading status and last-read progress.
- Statistics snapshots for ranking/trending without recalculating heavy aggregates.

## Files Added

- `refactor/Domain/MangaCatalogEnums.cs`
- `refactor/Domain/MangaCatalogEntities.cs`
- `refactor/Infrastructure/MangaCatalogConfigurations.cs`

These are not included in the current `.csproj`; they are review artifacts. To
apply them, move the Domain files into `YAHALLO.Domain` and the configuration
file into `YAHALLO.Infrastructure`, then add DbSet properties and a migration.

