using DDA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.Repositories.ItemRepository
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(int id);
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Item>> GetItemsByCategory(int catId);
    }
}
