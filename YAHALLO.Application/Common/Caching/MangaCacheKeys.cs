namespace YAHALLO.Application.Common.Caching
{
    public static class MangaCacheKeys
    {
        public const string CatalogPrefix = "manga:catalog";

        public static string Catalog(string type, int pageNumber, int pageSize)
        {
            return $"{CatalogPrefix}:{type.ToLowerInvariant()}:page:{pageNumber}:size:{pageSize}";
        }

        public static IEnumerable<string> CatalogKeysForDefaultPages()
        {
            var types = new[]
            {
                "newest",
                "popular",
                "top-view-day",
                "top-view-month",
                "top-view-year"
            };

            foreach (var type in types)
            {
                yield return Catalog(type, 1, 10);
                yield return Catalog(type, 1, 20);
                yield return Catalog(type, 1, 50);
            }
        }
    }
}

