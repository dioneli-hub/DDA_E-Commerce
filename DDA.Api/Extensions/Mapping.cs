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

        public static IEnumerable<CartItemModel> ConvertToModel(this IEnumerable<CartItem> cartItems,
            IEnumerable<Item> items)
        {
            return (from cartItem in cartItems
                join item in items
                    on cartItem.ItemId equals item.Id
                select new CartItemModel
                {
                    Id = cartItem.Id,
                    ItemId = cartItem.ItemId,
                    ItemDescription = item.Description,
                    ItemImage = item.Image,
                    Price = item.Price,
                    CartId = cartItem.CartId,
                    Quantity = cartItem.Quantity,
                    Total = item.Price * item.Quantity
                }).ToList();
        }

        public static UserModel ConvertToModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
