using DDA.ApiModels;
using DDA.Domain;

namespace DDA.Api.Extensions
{
    public static class Mapping
    {
        public static IEnumerable<ItemModel> ConvertToModel(this IEnumerable<Item> items, IEnumerable<Category> categories)
        {
            return (from item in items
                    join category in categories on item.CategoryId equals category.Id
                    select new ItemModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        Image = item.Image,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        CategoryId = item.CategoryId,
                        CategoryName = category.Name,
                    }).ToList();
        }

        public static ItemModel ConvertToModel(this Item item, Category category)
        {
            return new ItemModel
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Image = item.Image,
                Price = item.Price,
                Quantity = item.Quantity,
                CategoryId = item.CategoryId,
                CategoryName = category.Name,
            }; 
        }
    }
}
