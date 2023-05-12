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

        public async Task<IEnumerable<ItemModel>> GetItems()
        {
            try
            {
                var items = await _httpClient.GetFromJsonAsync<IEnumerable<ItemModel>>("api/item");
                return items;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
