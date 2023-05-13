using DDA.BusinessLogic.Repositories.ItemRepository;
using DDA.BusinessLogic.Services.ItemService;
using Microsoft.Extensions.DependencyInjection;
namespace DDA.BusinessLogic
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
        {
            //Api
            services.AddScoped<IItemRepository, ItemRepository>();
            //Web
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7207/") });

            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        policy =>
            //        {
            //            policy.WithOrigins("http://localhost:7207", "https://localhost:7207");
            //        });
            //});

            return services;
        }
    }
}
