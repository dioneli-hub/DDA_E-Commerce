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

                throw;
            }
        }

        public async Task<IEnumerable<ItemModel>> GetItems()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/item");
                
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
    }
}
