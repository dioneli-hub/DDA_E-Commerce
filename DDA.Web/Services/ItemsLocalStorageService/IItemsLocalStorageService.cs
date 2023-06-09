using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDA.ApiModels;

namespace DDA.Web.Services.ItemsLocalStorageService
{
    public interface IItemsLocalStorageService
    {
        Task<IEnumerable<ItemModel>> GetCollection();
        Task DeleteCollection();
    }
}
