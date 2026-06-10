//AI generated
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Persistence.Data.Configurations;
using YAHALLO.Infrastructure.Persistence.Data.Configurations.Reference;

namespace YAHALLO.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<AuthorEntity>? AuthorEntities { get; set; } 
        public DbSet<ArtistEntity>? ArtistsEntities { get; set; }
        public DbSet<MangaAssociateNameEntity>? MangaAssociateNames { get; set; }
        public DbSet<ChapterEntity>? ChaptersEntities { get; set; }
        public DbSet<CommentEntity>? CommentEntities { get; set; }
        public DbSet<FollowEntity>? FollowEntities { get; set; }
        public DbSet<ImageEntity>? ImageEntities { get; set; }   
        public DbSet<MangaEntity>? MangaEntities { get; set; }
        public DbSet<MangaRatingEntity>? MangaRatingEntities { get; set; }
        public DbSet<MangaSeasonEntity>? MangaSeasonEntities { get; set; }
        public DbSet<MangaViewEntity>? MangaViewEntities { get; set; }
        public DbSet<RoleEntity>? RoleEntities { get; set; }
        public DbSet<UserRoleEntity>? UserRoles { get; set; }
        public DbSet<UserEntity>? UserEntities { get; set; }
        public DbSet<MangaArtistEntity> MangaArtistEntities { get; set; }
        public DbSet<MangaAuthorEntity> MangaAuthorEntities { get; set; }
        public DbSet<UserTokenEntity> UserTokens { get; set; }
        public DbSet<CountingEntitity> Counting { get; set; }
        public DbSet<ReactionEntity> Reactions { get; set; }
        public DbSet<ThreadEntity> Threads { get; set; }
        public DbSet<ThreadOfBlogEntity> ThreadOfBlogs { get; set; }
        public DbSet<UserOldPasswordEntity> UserOldPasswords { get;set; }
        public DbSet<AttachmentEntity> Attechments { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<BlogEntity> Blogs { get; set; }

        // AI generated — new tables
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<MangaTagEntity> MangaTags { get; set; }
        public DbSet<ReadingProgressEntity> ReadingProgresses { get; set; }
        public DbSet<NotificationEntity> Notifications { get; set; }
        public DbSet<UserMangaViewEntity> UserMangaViews { get; set; }
        public DbSet<SubscriptionEntity> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var et in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(et.ClrType))
                {
                    var p = Expression.Parameter(et.ClrType, "e");
                    var body = Expression.AndAlso(
                        Expression.Call(typeof(string), nameof(string.IsNullOrEmpty), null,
                            Expression.Property(p, nameof(ISoftDelete.IdUserDelete))),
                        Expression.Equal(
                            Expression.Property(p, nameof(ISoftDelete.DeleteDate)),
                            Expression.Constant(null)));
                    modelBuilder.Entity(et.ClrType).HasQueryFilter(Expression.Lambda(body, p));
                }
            }
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new AssociateNameConfiguration());
            modelBuilder.ApplyConfiguration(new ChapterConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new FollowConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new MangaConfiguration());
            modelBuilder.ApplyConfiguration(new MangaRatingConfiguration());
            modelBuilder.ApplyConfiguration(new MangaViewConfiguration());
            modelBuilder.ApplyConfiguration(new MangaSeasonConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MangaArtistConfiguration());
            modelBuilder.ApplyConfiguration(new MangaAuthorConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenConfiguration());

            modelBuilder.ApplyConfiguration(new CountingConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
            modelBuilder.ApplyConfiguration(new ThreadConfiguration());
            modelBuilder.ApplyConfiguration(new ThreadOfBlogConfiguration());
            modelBuilder.ApplyConfiguration(new UserOldPasswordConfiguration());
            modelBuilder.ApplyConfiguration(new AttechmentConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());

            // AI generated — new configurations
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new MangaTagConfiguration());
            modelBuilder.ApplyConfiguration(new ReadingProgressConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new UserMangaViewConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());

    }
        protected void CreateData(ModelBuilder builder)
        {
            builder.Entity<RoleEntity>().HasData(
                new RoleEntity { RoleCode = 1, RoleName = "Admin", RoleDescription = "Only Admin has this Role" },
                new RoleEntity { RoleCode = 2, RoleName = "User", RoleDescription = "Normal User or New User has this Role" },
                new RoleEntity { RoleCode = 3, RoleName = "Mod", RoleDescription = "Role for Moderator" },
                new RoleEntity { RoleCode = 4, RoleName = "Upload", RoleDescription = "If User has this role then User can use Create, Update, Delete Manga" }
                );
        }
    }
}
