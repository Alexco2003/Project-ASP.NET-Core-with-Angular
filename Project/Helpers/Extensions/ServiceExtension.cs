using Project.Helpers.Seeders;
using Project.Repositories.MovieRepository;
using Project.Repositories.SubscriptionRepository;
using Project.Repositories.UserMovie_Review_Repository;
using Project.Repositories.UserRepository;
using Project.Services.MovieService;
using Project.Services.SubscriptionService;
using Project.Services.UserMovie_Review_Service;
using Project.Services.UserService;

namespace Project.Helpers.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IUserMovie_Review_Repository, UserMovie_Review_Repository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IUserMovie_Review_Service, UserMovie_Review_Service>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<UserSubscriptionMoviesSeeder>();
            services.AddTransient<RolesSeeder>();
            services.AddTransient<UserMovie_Review_Seeder>();
            services.AddTransient<UserRoleSeeder>();

            return services;
        }
    }
}
