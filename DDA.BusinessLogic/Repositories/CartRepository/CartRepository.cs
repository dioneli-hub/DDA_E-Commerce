using DDA.ApiModels;
using DDA.BusinessLogic.UserContext;
using DDA.DataAccess;
using DDA.Domain;
using Microsoft.EntityFrameworkCore;

namespace DDA.BusinessLogic.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUserContextService _userContextService;

        public CartRepository(DataContext dataContext, IUserContextService userContextService)
        {
            _dataContext = dataContext;
            _userContextService = userContextService;
        }

        private async Task<bool> CartItemExists(int cartId, int itemId)
        {
            return await _dataContext.CartItems.AnyAsync(c => c.CartId == cartId && c.ItemId == itemId);
        }
        public async Task<CartItem> AddCartItem(AddCartItemModel addCartItemModel)
        {
            if (await CartItemExists(addCartItemModel.CartId, addCartItemModel.ItemId) is false)
            {
                var currentUserId = _userContextService.GetCurrentUserId();
                var currentUserCart = await _dataContext.Carts
                                        .Where(x => x.UserId == currentUserId)
                                        .FirstOrDefaultAsync();
                                            

                var cartItem = await (from item in _dataContext.Items
                    where item.Id == addCartItemModel.ItemId
                    select new CartItem()
                    {
                        
                        CartId = currentUserCart.Id,
                        ItemId = item.Id,
                        Quantity = addCartItemModel.Quantity,
                    }).SingleOrDefaultAsync();

                if (cartItem is not null)
                {
                    var result = await _dataContext.CartItems.AddAsync(cartItem);
                    await _dataContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            return null;
        }

        public async Task<CartItem> UpdateCartItemQuantity(int id, UpdateCartItemQuantityModel updateCartItemQuantityModel)
        {
            var cartItem = await this._dataContext.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                cartItem.Quantity = updateCartItemQuantityModel.Quantity;
                await this._dataContext.SaveChangesAsync();
                return cartItem;
            }

            return null;
        }

        public async Task<CartItem> RemoveCartItem(int id)
        {
            var cartItem = await _dataContext.CartItems.FindAsync(id);

            if (cartItem != null)
            {
                _dataContext.CartItems.Remove(cartItem);
                await _dataContext.SaveChangesAsync();
            }

            return cartItem;
        }

        public async Task<CartItem> GetCartItem(int id)
        {
            return await (from cart in _dataContext.Carts
                join cartItem in _dataContext.CartItems 
                on cart.Id equals cartItem.CartId
                where cartItem.Id == id
                select new CartItem
                {
                    Id = cartItem.Id,
                    ItemId = cartItem.ItemId,
                    Quantity = cartItem.Quantity,
                    CartId = cartItem.CartId
                }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetUsersCartItems(int userId)
        {
            return await (from cart in _dataContext.Carts
                join cartItem in _dataContext.CartItems 
                on cart.Id equals cartItem.CartId
                where cart.UserId == userId
                select new CartItem
                {
                    Id = cartItem.Id,
                    ItemId = cartItem.ItemId,
                    Quantity = cartItem.Quantity,
                    CartId = cartItem.CartId

                }).ToListAsync();
        }
    }
}
