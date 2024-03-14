using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data.Configurations;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
        }
    }
}
