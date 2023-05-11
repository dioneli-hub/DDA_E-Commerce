using DDA.DataAccess;
using DDA.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.Repositories.ItemRepository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _dataContext;

        public ItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _dataContext.Categories.ToListAsync();

            return categories;
        }

        public Task<Category> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            var items = await _dataContext.Items.ToListAsync();

            return items;
        }
    }
}
