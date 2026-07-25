namespace YAHALLO.Application.Common.Caching
{
    public class CacheSettings
    {
        public int MangaDetailTtlMinutes { get; set; } = 10;
        public int HomepageTtlMinutes { get; set; } = 2;

        public int AuthorTtlMinutes { get; set; } = 15;
        public int ArtistTtlMinutes { get; set; } = 15;
    }
}
