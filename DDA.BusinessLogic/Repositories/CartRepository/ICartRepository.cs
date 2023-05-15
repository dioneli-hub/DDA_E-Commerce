using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDA.ApiModels;
using DDA.Domain;

namespace DDA.BusinessLogic.Repositories.CartRepository
{
    public interface ICartRepository
    {
        Task<CartItem> AddCartItem(AddCartItemModel addCartItemModel);
        Task<CartItem> UpdateCartItemQuantity(int id, UpdateCartItemQuantityModel updateCartItemQuantityModel);
        Task<CartItem> DeleteCartItem(int id);
        Task<CartItem> GetCartItem(int id);
        Task<IEnumerable<CartItem>> GetUsersCartItems(int userId);
    }
}
