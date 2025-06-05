using dotenv.net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;
using YAHALLO.Infrastructure.Functions;
using YAHALLO.Infrastructure.Repositories;

namespace YAHALLO.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection Infrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            DotEnv.Load();
            var sqlConnection = Environment.GetEnvironmentVariable("Server");
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    sqlConnection,
                    //configuration.GetConnectionString("Server"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        b.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
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
            services.AddTransient<IAttechmentRepository, AttechmentRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IUserOldPasswordRepository, UserOldPasswordRepository>();
            services.AddTransient<IThreadRepository, ThreadRepository>();
            services.AddTransient<IThreadOfBlogRepository, ThreadOfBlogRepository>();
            services.AddTransient<IReactionRepository, ReactionRepository>();
            services.AddTransient<ICountingRepository, CountingRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IEnums, Enums>();

            services.AddTransient<IFiles<IFormFile>, Files<IFormFile>>();
            services.AddTransient<IFilters, Filters>();
            return services;
        }
    }
}
