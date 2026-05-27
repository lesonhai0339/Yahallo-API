using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations;

public sealed class MangaMetadataConfiguration : IEntityTypeConfiguration<MangaMetadataEntity>
{
    public void Configure(EntityTypeBuilder<MangaMetadataEntity> builder)
    {
        builder.ToTable("MangaMetadata");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.MangaId).IsUnique();
        builder.Property(x => x.OriginalLanguage).HasMaxLength(12).IsRequired();
        builder.Property(x => x.LastVolume).HasMaxLength(32);
        builder.Property(x => x.LastChapter).HasMaxLength(32);
        builder.Property(x => x.SourceSlug).HasMaxLength(64);
        builder.Property(x => x.SourceId).HasMaxLength(128);
        builder.HasOne(x => x.Manga)
            .WithOne()
            .HasForeignKey<MangaMetadataEntity>(x => x.MangaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class MangaTitleConfiguration : IEntityTypeConfiguration<MangaTitleEntity>
{
    public void Configure(EntityTypeBuilder<MangaTitleEntity> builder)
    {
        builder.ToTable("MangaTitle");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.MangaId, x.LanguageCode, x.Title }).IsUnique();
        builder.Property(x => x.LanguageCode).HasMaxLength(12).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(512).IsUnicode().IsRequired();
        builder.HasOne(x => x.Manga)
            .WithMany()
            .HasForeignKey(x => x.MangaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class MangaDescriptionConfiguration : IEntityTypeConfiguration<MangaDescriptionEntity>
{
    public void Configure(EntityTypeBuilder<MangaDescriptionEntity> builder)
    {
        builder.ToTable("MangaDescription");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.MangaId, x.LanguageCode }).IsUnique();
        builder.Property(x => x.LanguageCode).HasMaxLength(12).IsRequired();
        builder.Property(x => x.Description).IsUnicode().IsRequired();
        builder.HasOne(x => x.Manga)
            .WithMany()
            .HasForeignKey(x => x.MangaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class MangaTagConfiguration : IEntityTypeConfiguration<MangaTagEntity>
{
    public void Configure(EntityTypeBuilder<MangaTagEntity> builder)
    {
        builder.ToTable("MangaTag");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(x => x.Code).HasMaxLength(128).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(256).IsUnicode().IsRequired();
        builder.Property(x => x.Group).HasMaxLength(64);
    }
}

public sealed class MangaTagNameConfiguration : IEntityTypeConfiguration<MangaTagNameEntity>
{
    public void Configure(EntityTypeBuilder<MangaTagNameEntity> builder)
    {
        builder.ToTable("MangaTagName");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.TagId, x.LanguageCode }).IsUnique();
        builder.Property(x => x.LanguageCode).HasMaxLength(12).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(256).IsUnicode().IsRequired();
        builder.HasOne(x => x.Tag)
            .WithMany(x => x.LocalizedNames)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class MangaTagMappingConfiguration : IEntityTypeConfiguration<MangaTagMappingEntity>
{
    public void Configure(EntityTypeBuilder<MangaTagMappingEntity> builder)
    {
        builder.ToTable("MangaTagMapping");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.MangaId, x.TagId }).IsUnique();
        builder.HasOne(x => x.Manga)
            .WithMany()
            .HasForeignKey(x => x.MangaId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Tag)
            .WithMany(x => x.MangaMappings)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class MangaExternalLinkConfiguration : IEntityTypeConfiguration<MangaExternalLinkEntity>
{
    public void Configure(EntityTypeBuilder<MangaExternalLinkEntity> builder)
    {
        builder.ToTable("MangaExternalLink");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.MangaId, x.Type }).IsUnique();
        builder.Property(x => x.Url).HasMaxLength(2048).IsRequired();
        builder.Property(x => x.ExternalId).HasMaxLength(256);
        builder.HasOne(x => x.Manga)
            .WithMany()
            .HasForeignKey(x => x.MangaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class MangaRelationConfiguration : IEntityTypeConfiguration<MangaRelationEntity>
{
    public void Configure(EntityTypeBuilder<MangaRelationEntity> builder)
    {
        builder.ToTable("MangaRelation");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.MangaId, x.RelatedMangaId, x.RelationType }).IsUnique();
        builder.HasOne(x => x.Manga)
            .WithMany()
            .HasForeignKey(x => x.MangaId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.RelatedManga)
            .WithMany()
            .HasForeignKey(x => x.RelatedMangaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class MangaCoverArtConfiguration : IEntityTypeConfiguration<MangaCoverArtEntity>
{
    public void Configure(EntityTypeBuilder<MangaCoverArtEntity> builder)
    {
        builder.ToTable("MangaCoverArt");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.MangaId, x.FileName }).IsUnique();
        builder.Property(x => x.FileName).HasMaxLength(512).IsRequired();
        builder.Property(x => x.StoragePath).HasMaxLength(1024).IsRequired();
        builder.Property(x => x.PublicUrl).HasMaxLength(2048);
        builder.Property(x => x.Volume).HasMaxLength(32);
        builder.Property(x => x.Locale).HasMaxLength(12);
        builder.HasOne(x => x.Manga)
            .WithMany()
            .HasForeignKey(x => x.MangaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class ScanlationGroupConfiguration : IEntityTypeConfiguration<ScanlationGroupEntity>
{
    public void Configure(EntityTypeBuilder<ScanlationGroupEntity> builder)
    {
        builder.ToTable("ScanlationGroup");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name).HasMaxLength(256).IsUnicode().IsRequired();
        builder.Property(x => x.WebsiteUrl).HasMaxLength(2048);
        builder.Property(x => x.DiscordUrl).HasMaxLength(2048);
        builder.Property(x => x.ContactEmail).HasMaxLength(320);
    }
}

public sealed class ChapterScanlationGroupConfiguration : IEntityTypeConfiguration<ChapterScanlationGroupEntity>
{
    public void Configure(EntityTypeBuilder<ChapterScanlationGroupEntity> builder)
    {
        builder.ToTable("ChapterScanlationGroup");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.ChapterId, x.ScanlationGroupId }).IsUnique();
        builder.HasOne(x => x.Chapter)
            .WithMany()
            .HasForeignKey(x => x.ChapterId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.ScanlationGroup)
            .WithMany(x => x.Chapters)
            .HasForeignKey(x => x.ScanlationGroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class ChapterMetadataConfiguration : IEntityTypeConfiguration<ChapterMetadataEntity>
{
    public void Configure(EntityTypeBuilder<ChapterMetadataEntity> builder)
    {
        builder.ToTable("ChapterMetadata");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.ChapterId).IsUnique();
        builder.Property(x => x.Volume).HasMaxLength(32);
        builder.Property(x => x.ChapterNumber).HasPrecision(10, 3);
        builder.Property(x => x.LanguageCode).HasMaxLength(12).IsRequired();
        builder.Property(x => x.SourceId).HasMaxLength(128);
        builder.HasOne(x => x.Chapter)
            .WithOne()
            .HasForeignKey<ChapterMetadataEntity>(x => x.ChapterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class ChapterPageConfiguration : IEntityTypeConfiguration<ChapterPageEntity>
{
    public void Configure(EntityTypeBuilder<ChapterPageEntity> builder)
    {
        builder.ToTable("ChapterPage");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.ChapterId, x.PageIndex }).IsUnique();
        builder.Property(x => x.FileName).HasMaxLength(512).IsRequired();
        builder.Property(x => x.StoragePath).HasMaxLength(1024).IsRequired();
        builder.Property(x => x.PublicUrl).HasMaxLength(2048);
        builder.Property(x => x.Sha256Hash).HasMaxLength(64);
        builder.HasOne(x => x.Chapter)
            .WithMany()
            .HasForeignKey(x => x.ChapterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public sealed class UserMangaLibraryConfiguration : IEntityTypeConfiguration<UserMangaLibraryEntity>
{
    public void Configure(EntityTypeBuilder<UserMangaLibraryEntity> builder)
    {
        builder.ToTable("UserMangaLibrary");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.UserId, x.MangaId }).IsUnique();
        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Manga)
            .WithMany()
            .HasForeignKey(x => x.MangaId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.LastReadChapter)
            .WithMany()
            .HasForeignKey(x => x.LastReadChapterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class MangaStatisticsSnapshotConfiguration : IEntityTypeConfiguration<MangaStatisticsSnapshotEntity>
{
    public void Configure(EntityTypeBuilder<MangaStatisticsSnapshotEntity> builder)
    {
        builder.ToTable("MangaStatisticsSnapshot");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => new { x.MangaId, x.CapturedAtUtc }).IsUnique();
        builder.Property(x => x.AverageRating).HasPrecision(5, 2);
        builder.Property(x => x.BayesianRating).HasPrecision(5, 2);
        builder.HasOne(x => x.Manga)
            .WithMany()
            .HasForeignKey(x => x.MangaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

