using BusinessLogicLayer.Services;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantMangementSystem.Repositories;


namespace BusinessLogicLayer
{
    public static class DIConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            services.AddDalServices(configuration);
            return services;
        }
    }
    
}

