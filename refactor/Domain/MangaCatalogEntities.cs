using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Domain.Entities;

public class MangaMetadataEntity : BaseEntity
{
    public string MangaId { get; set; } = null!;
    public virtual MangaEntity Manga { get; set; } = null!;

    public string OriginalLanguage { get; set; } = "ja";
    public int? ReleaseYear { get; set; }
    public string? LastVolume { get; set; }
    public string? LastChapter { get; set; }
    public MangaPublicationDemographic PublicationDemographic { get; set; }
    public MangaContentRating ContentRating { get; set; } = MangaContentRating.Safe;
    public MangaPublicationState PublicationState { get; set; } = MangaPublicationState.Draft;
    public bool IsLocked { get; set; }
    public string? SourceSlug { get; set; }
    public string? SourceId { get; set; }
}

public class MangaTitleEntity : BaseEntity
{
    public string MangaId { get; set; } = null!;
    public virtual MangaEntity Manga { get; set; } = null!;

    public string LanguageCode { get; set; } = "ja";
    public string Title { get; set; } = null!;
    public bool IsPrimary { get; set; }
}

public class MangaDescriptionEntity : BaseEntity
{
    public string MangaId { get; set; } = null!;
    public virtual MangaEntity Manga { get; set; } = null!;

    public string LanguageCode { get; set; } = "en";
    public string Description { get; set; } = null!;
}

public class MangaTagEntity : BaseEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Group { get; set; }
    public virtual ICollection<MangaTagNameEntity> LocalizedNames { get; set; } = new List<MangaTagNameEntity>();
    public virtual ICollection<MangaTagMappingEntity> MangaMappings { get; set; } = new List<MangaTagMappingEntity>();
}

public class MangaTagNameEntity : BaseEntity
{
    public string TagId { get; set; } = null!;
    public virtual MangaTagEntity Tag { get; set; } = null!;

    public string LanguageCode { get; set; } = "en";
    public string Name { get; set; } = null!;
}

public class MangaTagMappingEntity : BaseEntity
{
    public string MangaId { get; set; } = null!;
    public virtual MangaEntity Manga { get; set; } = null!;

    public string TagId { get; set; } = null!;
    public virtual MangaTagEntity Tag { get; set; } = null!;
}

public class MangaExternalLinkEntity : BaseEntity
{
    public string MangaId { get; set; } = null!;
    public virtual MangaEntity Manga { get; set; } = null!;

    public MangaLinkType Type { get; set; }
    public string Url { get; set; } = null!;
    public string? ExternalId { get; set; }
}

public class MangaRelationEntity : BaseEntity
{
    public string MangaId { get; set; } = null!;
    public virtual MangaEntity Manga { get; set; } = null!;

    public string RelatedMangaId { get; set; } = null!;
    public virtual MangaEntity RelatedManga { get; set; } = null!;

    public MangaRelationType RelationType { get; set; }
}

public class MangaCoverArtEntity : BaseEntity
{
    public string MangaId { get; set; } = null!;
    public virtual MangaEntity Manga { get; set; } = null!;

    public string FileName { get; set; } = null!;
    public string StoragePath { get; set; } = null!;
    public string? PublicUrl { get; set; }
    public string? Volume { get; set; }
    public string? Locale { get; set; }
    public bool IsPrimary { get; set; }
}

public class ScanlationGroupEntity : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? WebsiteUrl { get; set; }
    public string? DiscordUrl { get; set; }
    public string? ContactEmail { get; set; }
    public bool IsInactive { get; set; }
    public virtual ICollection<ChapterScanlationGroupEntity> Chapters { get; set; } = new List<ChapterScanlationGroupEntity>();
}

public class ChapterScanlationGroupEntity : BaseEntity
{
    public string ChapterId { get; set; } = null!;
    public virtual ChapterEntity Chapter { get; set; } = null!;

    public string ScanlationGroupId { get; set; } = null!;
    public virtual ScanlationGroupEntity ScanlationGroup { get; set; } = null!;
}

public class ChapterMetadataEntity : BaseEntity
{
    public string ChapterId { get; set; } = null!;
    public virtual ChapterEntity Chapter { get; set; } = null!;

    public string? Volume { get; set; }
    public decimal? ChapterNumber { get; set; }
    public string LanguageCode { get; set; } = "en";
    public int PageCount { get; set; }
    public string? SourceId { get; set; }
    public DateTime? ReadableAtUtc { get; set; }
    public DateTime? PublishedAtUtc { get; set; }
}

public class ChapterPageEntity : BaseEntity
{
    public string ChapterId { get; set; } = null!;
    public virtual ChapterEntity Chapter { get; set; } = null!;

    public int PageIndex { get; set; }
    public string FileName { get; set; } = null!;
    public string StoragePath { get; set; } = null!;
    public string? PublicUrl { get; set; }
    public string? Sha256Hash { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
}

public class UserMangaLibraryEntity : BaseEntity
{
    public string UserId { get; set; } = null!;
    public virtual UserEntity User { get; set; } = null!;

    public string MangaId { get; set; } = null!;
    public virtual MangaEntity Manga { get; set; } = null!;

    public UserMangaReadingStatus Status { get; set; }
    public string? LastReadChapterId { get; set; }
    public virtual ChapterEntity? LastReadChapter { get; set; }
    public DateTime? LastReadAtUtc { get; set; }
}

public class MangaStatisticsSnapshotEntity : BaseEntity
{
    public string MangaId { get; set; } = null!;
    public virtual MangaEntity Manga { get; set; } = null!;

    public DateTime CapturedAtUtc { get; set; }
    public int Follows { get; set; }
    public int Comments { get; set; }
    public int Views { get; set; }
    public decimal? AverageRating { get; set; }
    public decimal? BayesianRating { get; set; }
}

