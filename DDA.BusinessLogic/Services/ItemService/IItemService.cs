using DDA.ApiModels;

namespace DDA.BusinessLogic.Services.ItemService
{
    public interface IItemService
    {
        Task<IEnumerable<ItemModel>> GetItems();
    }
}
