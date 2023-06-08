using DDA.ApiModels;
using System.Net.Http.Json;

namespace DDA.BusinessLogic.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ItemModel>> GetCategories()
        {
            try 
            {
                var response = await _httpClient.GetAsync("api/Item/GetCategories");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ItemModel>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ItemModel>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode}");
                }
            }
            catch (Exception)
            {
                // log exception
                throw;
            }
        }

        public async Task<ItemModel> GetItem(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Item/{id}");

                if(response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent) 
                    {
                        return default(ItemModel);
                    }
                    return await response.Content.ReadFromJsonAsync<ItemModel>();
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

        public async Task<IEnumerable<ItemModel>> GetItems()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Item");
                
                if(response.IsSuccessStatusCode) 
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ItemModel>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ItemModel>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ItemModel>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Item/{categoryId}/GetItemsByCategory");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ItemModel>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ItemModel>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode}");
                }
            }
            catch (Exception)
            {
                // log exception
                throw;
            }
        }
    }
}
