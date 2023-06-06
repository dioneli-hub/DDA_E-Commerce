using DDA.BusinessLogic.UserContext;
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
        private readonly IUserContextService _userContextService;

        public ItemRepository(DataContext dataContext, IUserContextService userContextService)
        {
            _dataContext = dataContext;
            _userContextService = userContextService;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _dataContext.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _dataContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Item> GetItem(int id)
        {
            var item = await _dataContext.Items.FindAsync(id);
            return item;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            var items = await _dataContext.Items.ToListAsync();

            return items;
        }
    }
}
