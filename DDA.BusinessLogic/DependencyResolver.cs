global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using DDA.BusinessLogic.Repositories.AuthRepository;
using DDA.BusinessLogic.Repositories.CartRepository;
using DDA.BusinessLogic.Repositories.ItemRepository;
using DDA.BusinessLogic.Repositories.UserRepository;
using DDA.BusinessLogic.Services.AuthService;
using DDA.BusinessLogic.Services.CartItemsLocalStorageService;
using DDA.BusinessLogic.Services.CartService;
using DDA.BusinessLogic.Services.ItemService;
using DDA.BusinessLogic.Services.ItemsLocalStorageService;
using DDA.BusinessLogic.Services.UserService;
using DDA.BusinessLogic.UserContext;
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
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            return services;
        }

        public static IServiceCollection AddWebBusinessLogicDependencies(this IServiceCollection services)
        {
            //Web
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            services.AddOptions();
            services.AddAuthorizationCore();

            //Local storage
            services.AddBlazoredLocalStorage();
            services.AddScoped<IItemsLocalStorageService, ItemsLocalStorageService>();
            services.AddScoped<ICartItemsLocalStorageService, CartItemsLocalStorageService>();

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7207/") });

            return services;
        }
    }
}
