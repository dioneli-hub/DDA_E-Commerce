using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDA.ApiModels;

namespace DDA.Web.Services.CartItemsLocalStorageService
{
    public interface ICartItemsLocalStorageService
    {
        Task<List<CartItemModel>> GetCollection();
        Task SaveCollection(List<CartItemModel> itemModels);
        Task DeleteCollection();
    }
}
