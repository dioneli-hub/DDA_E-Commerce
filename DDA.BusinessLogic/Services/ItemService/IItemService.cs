using DDA.ApiModels;

namespace DDA.BusinessLogic.Services.ItemService
{
    public interface IItemService
    {
        Task<IEnumerable<ItemModel>> GetItems();
        Task<ItemModel> GetItem(int id);
        Task<IEnumerable<ItemModel>> GetCategories();
        Task<IEnumerable<ItemModel>> GetItemsByCategory(int categoryId);
    }
}
