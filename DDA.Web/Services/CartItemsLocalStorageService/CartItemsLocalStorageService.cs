using Blazored.LocalStorage;
using DDA.ApiModels;
using DDA.Web.Services.AuthService;
using DDA.Web.Services.CartService;

namespace DDA.Web.Services.CartItemsLocalStorageService
{
    public class CartItemsLocalStorageService : ICartItemsLocalStorageService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly ICartService _cartService;
        private readonly IAuthService _authService;

        private const string key = "CartItemsCollection";

        public CartItemsLocalStorageService(ILocalStorageService localStorage, ICartService cartService, IAuthService authService)
        {
            _localStorage = localStorage;
            _cartService = cartService;
            _authService = authService;
        }
        public async Task<List<CartItemModel>> GetCollection()
        {
            //return await _localStorage.GetItemAsync<List<CartItemModel>>(key) ?? await AddCollection();
            return await _localStorage.GetItemAsync<List<CartItemModel>>(key) ?? await AddCollection();
        }

        public async Task SaveCollection(List<CartItemModel> cartItemModels)
        {
            await _localStorage.SetItemAsync(key, cartItemModels);
        }

        public async Task DeleteCollection()
        {
            await _localStorage.RemoveItemAsync(key);
        }

        private async Task<List<CartItemModel>> AddCollection()
        {
            Console.WriteLine(await _authService.IsAuthenticated());
            if (await _authService.IsAuthenticated())
            {
                Console.WriteLine("at add collection");

                var cartCollection = await _cartService.GetUsersCartItems();

                if (cartCollection != null)
                {
                    await _localStorage.SetItemAsync(key, cartCollection);
                }

                return cartCollection;
            }
            return new List<CartItemModel>();

        }
    }
}
