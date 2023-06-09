using DDA.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.Web.Services.CartService
{
    public interface ICartService
    {
        Task<List<CartItemModel>> GetUsersCartItems();
        Task<CartItemModel> AddCartItem(AddCartItemModel addCartItemModel);
        Task<CartModel> GetUserCart();
        Task<CartItemModel> RemoveCartItem(int cartItemId);
        Task<CartItemModel> UpdateQuantity(UpdateCartItemQuantityModel updateCartItemQuantityModel);

        event Action<int> OnShoppingCartChanged;
        void RaiseEventOnShoppingCartChanged(int totalQuantity);
    }
}
