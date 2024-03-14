using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;
using YAHALLO.Infrastructure.Repositories;

namespace YAHALLO.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection Infrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("Server"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
                options.UseLazyLoadingProxies();
            });
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IMangaRepository, MangaRepository>();
            services.AddTransient<IChapterRepository, ChapterRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IMangaArtistRepository, MangaArtistRepository>();
            services.AddTransient<IMangaAuthorRepository, MangaAuthorRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IFollowRepository, FollowRepository>();
            services.AddTransient<IMangaAssociateNameRepository, MangaAssociateNameRepository>();
            services.AddTransient<IMangaRatingRepository, MangaRatingRepository>(); 
            services.AddTransient<IMangaSeasonRepository, MangaSeasonRepository>();
            services.AddTransient<IMangaViewRepository, MangaViewRepository>();
            services.AddTransient<IUserTokenRepository, UserTokenRepository>();
            return services;
        }
    }
}
