using DDA.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.Services.CartService
{
    public interface ICartService
    {
        Task<List<CartItemModel>> GetUsersCartItems(int userId);
        Task<CartItemModel> AddCartItem(AddCartItemModel addCartItemModel);
        Task<CartModel> GetUserCart(int userId);
        Task<CartItemModel> RemoveCartItem(int cartItemId);
    }
}
