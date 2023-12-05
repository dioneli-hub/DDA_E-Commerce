global using Microsoft.AspNetCore.Components.Authorization;
using DDA.BusinessLogic.AuthSecurityManagers;
using DDA.BusinessLogic.AuthSecurityManagers.Contracts;
using DDA.BusinessLogic.Repositories.CartRepository;
using DDA.BusinessLogic.Repositories.ItemRepository;
using DDA.BusinessLogic.Repositories.UserRepository;
using Microsoft.Extensions.DependencyInjection;
namespace DDA.BusinessLogic
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddApiBusinessLogicDependencies(this IServiceCollection services)
        {
            //Api
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddScoped<IHashManager, HashManager>();
            services.AddScoped<IPasswordVerifier, PasswordVerifier>();

            return services;
        }
    }
}
