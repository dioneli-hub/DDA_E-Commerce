﻿using DDA.ApiModels;
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

        public async Task<List<CartItemModel>> GetUsersCartItems(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Cart/{userId}/GetUsersCartItems");

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

        public async Task<CartModel> GetUserCart(int userId)
        {
            var response = await _httpClient.GetAsync($"api/{userId}/GetUserCart");

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
    }
}
