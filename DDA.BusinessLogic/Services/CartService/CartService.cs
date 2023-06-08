using DDA.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DDA.BusinessLogic.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;

        public event Action<int> OnShoppingCartChanged;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CartItemModel> AddCartItem(AddCartItemModel addCartItemModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<AddCartItemModel>("api/Cart", addCartItemModel);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartItemModel);
                    }

                    return await response.Content.ReadFromJsonAsync<CartItemModel>();
                }

                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CartItemModel>> GetUsersCartItems()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Cart/GetUsersCartItems");

                if (response.IsSuccessStatusCode) 
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemModel>().ToList();
                    }
                    return await response.Content.ReadFromJsonAsync<List<CartItemModel>>();
                }

                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message: {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CartModel> GetUserCart()
        {
            var response = await _httpClient.GetAsync($"api/User/GetUserCart");

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartModel);
                    }
                    return await response.Content.ReadFromJsonAsync<CartModel>();
                }

                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }

            catch (Exception)
            {
                //Log later
                throw;
            }

        }

        public async Task<CartItemModel> RemoveCartItem(int cartItemId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Cart/{cartItemId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartItemModel>();
                }
                return default (CartItemModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<CartItemModel> UpdateQuantity(UpdateCartItemQuantityModel updateCartItemQuantityModel)
        {
            try
            {
                var jsonReq = JsonConvert.SerializeObject(updateCartItemQuantityModel);
                var content = new StringContent(jsonReq, Encoding.UTF8, "application/json-patch+json");
                var response =
                    await _httpClient.PatchAsync($"api/Cart/{updateCartItemQuantityModel.CartItemId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CartItemModel>();
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void RaiseEventOnShoppingCartChanged(int totalQuantity)
        {
            if(OnShoppingCartChanged != null) //event has subscribers
            {
                OnShoppingCartChanged.Invoke(totalQuantity); //sending the aapropriate number to all subscribers

            }
        }
    }
}
