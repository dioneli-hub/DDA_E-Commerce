global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using DDA.BusinessLogic;
using DDA.Web;
using DDA.Web.Services.AuthService;
using DDA.Web.Services.CartItemsLocalStorageService;
using DDA.Web.Services.CartService;
using DDA.Web.Services.ItemService;
using DDA.Web.Services.ItemsLocalStorageService;
using DDA.Web.Services.UserService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

//Local storage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IItemsLocalStorageService, ItemsLocalStorageService>();
builder.Services.AddScoped<ICartItemsLocalStorageService, CartItemsLocalStorageService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7207/") });

await builder.Build().RunAsync();


