using DDA.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CartItemModel> AddCartItem(AddCartItemModel addCartItemModel)
        {
            var response = await _httpClient.PostAsJsonAsync<AddCartItemModel>("api/Cart", addCartItemModel);

            if(response.IsSuccessStatusCode)
            {
                if(response.StatusCode is System.Net.HttpStatusCode.NoContent)
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

        public async Task<IEnumerable<CartItemModel>> GetUsersCartItems(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/{userId}/GetUsersCartItems");

                if (response.IsSuccessStatusCode) 
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemModel>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<CartItemModel>>();
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
    }
}
