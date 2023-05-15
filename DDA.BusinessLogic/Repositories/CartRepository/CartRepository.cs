using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DDA.ApiModels;
using DDA.DataAccess;
using DDA.Domain;
using Microsoft.EntityFrameworkCore;

namespace DDA.BusinessLogic.Repositories.CartRepository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext _dataContext;

        public CartRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private async Task<bool> CartItemExists(int cartId, int itemId)
        {
            return await _dataContext.CartItems.AnyAsync(c => c.CartId == cartId && c.ItemId == itemId);
        }
        public async Task<CartItem> AddCartItem(AddCartItemModel addCartItemModel)
        {
            if (await CartItemExists(addCartItemModel.CartId, addCartItemModel.ItemId) is false)
            {
                var cartItem = await (from item in _dataContext.Items
                    where item.Id == addCartItemModel.ItemId
                    select new CartItem()
                    {
                        CartId = addCartItemModel.CartId,
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

        public Task<CartItem> UpdateCartItemQuantity(int id, UpdateCartItemQuantityModel updateCartItemQuantityModel)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> DeleteCartItem(int id)
        {
            throw new NotImplementedException();
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
                join CartItem in _dataContext.CartItems 
                on cart.Id equals CartItem.CartId
                where cart.UserId == userId
                select new CartItem
                {
                    Id = CartItem.Id,
                    Quantity = CartItem.Quantity,
                    CartId = CartItem.CartId
                }).ToListAsync();
        }
    }
}
