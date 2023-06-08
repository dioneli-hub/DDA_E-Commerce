using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using DDA.ApiModels;
using DDA.BusinessLogic.Services.ItemService;

namespace DDA.BusinessLogic.Services.ItemsLocalStorageService
{
    public class ItemsLocalStorageService : IItemsLocalStorageService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IItemService _itemService;

        private const string key = "ItemsCollection";

        public ItemsLocalStorageService(ILocalStorageService localStorage, IItemService itemService)
        {
            _localStorage = localStorage;
            _itemService = itemService;
        }
        public async Task<IEnumerable<ItemModel>> GetCollection()
        {
            return await _localStorage.GetItemAsync<IEnumerable<ItemModel>>(key) ?? await AddCollection();
        }

        public async Task DeleteCollection()
        {
            await _localStorage.RemoveItemAsync(key);
        }

        private async Task<IEnumerable<ItemModel>> AddCollection()
        {
            var itemsCollection = await _itemService.GetItems();
            if (itemsCollection != null)
            {
                await _localStorage.SetItemAsync(key, itemsCollection);
            }

            return itemsCollection;
        }
    }
}
