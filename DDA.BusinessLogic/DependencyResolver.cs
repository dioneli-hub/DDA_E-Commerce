﻿using DDA.BusinessLogic.Repositories.AuthRepository;
using DDA.BusinessLogic.Repositories.ItemRepository;
using DDA.BusinessLogic.Repositories.UserRepository;
using DDA.BusinessLogic.Services.ItemService;
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
            services.AddScoped<IUserContextService, UserContextService>();

            return services;
        }

        public static IServiceCollection AddWebBusinessLogicDependencies(this IServiceCollection services)
        {
            //Web
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7207/") });

            return services;
        }
    }
}
