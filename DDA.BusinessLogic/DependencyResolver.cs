using DDA.BusinessLogic.Repositories.ItemRepository;
using Microsoft.Extensions.DependencyInjection;

namespace DDA.BusinessLogic
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
