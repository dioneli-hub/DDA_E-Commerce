using DDA.ApiModels;
using DDA.Domain;

namespace DDA.Api.Extensions
{
    public static class Mapping
    {
        public static IEnumerable<CategoryModel> ConvertToModel(this IEnumerable<Category> categories)
        {
            return (from c in categories
                    select new CategoryModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();
        }

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
                        ItemName = item.Name,
                        ItemDescription = item.Description,
                        ItemImage = item.Image,
                        Price = item.Price,
                        CartId = cartItem.CartId,
                        Quantity = cartItem.Quantity,
                        Total = item.Price * cartItem.Quantity
                    }).ToList();
        }

        public static CartItemModel ConvertToModel(this CartItem cartItem, Item item)
        {
            return new CartItemModel
                    {
                        Id = cartItem.Id,
                        ItemId = cartItem.ItemId,
                        ItemName = item.Name,
                        ItemDescription = item.Description,
                        ItemImage = item.Image,
                        Price = item.Price,
                        CartId = cartItem.CartId,
                        Quantity = cartItem.Quantity,
                        Total = item.Price * cartItem.Quantity
                    };
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

        public static CartModel ConvertToModel(this Cart cart)
        {
            return new CartModel
            {
                Id = cart.Id,
                UserId = cart.UserId
            };
        }
    }
}
