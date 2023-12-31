﻿using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.Repositories.CartRepository;
using DDA.BusinessLogic.Repositories.ItemRepository;
using DDA.BusinessLogic.UserContext;
using Microsoft.AspNetCore.Mvc;


namespace DDA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUserContextService _userContextService;
        public CartController(ICartRepository cartRepository,
            IItemRepository itemRepository, 
            IUserContextService userContextService)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
            _userContextService = userContextService;
        }

        [HttpGet]
        [Route("GetUsersCartItems")]
        public async Task<ActionResult<IEnumerable<CartItemModel>>> GetUsersCartItems()
        {
            int currentUserId = _userContextService.GetCurrentUserId();
            //if (currentUserId != null)
            //{
                try
                {
                    var cartItems =  await _cartRepository.GetUsersCartItems(currentUserId);

                    if (cartItems is null)
                    {
                        return NoContent();
                    }

                    var items = await _itemRepository.GetItems();

                    if (items is null)
                    {
                        throw new Exception("There are no products in the system.");
                    }

                    var cartItemsModel = cartItems.ConvertToModel(items);

                    return Ok(cartItemsModel);
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }
            //}

            return null;
        }

        [HttpGet("{id}/GetCartItem" , Name = nameof(GetCartItem))]
        public async Task<ActionResult<CartItemModel>> GetCartItem(int id)
        {
            try
            {
                var cartItem = await _cartRepository.GetCartItem(id);
                if(cartItem is null)
                {
                    return NotFound();
                }

                var item = await _itemRepository.GetItem(cartItem.ItemId);
                if (item is null)
                {
                    return NotFound();
                }

                var cartItemModel = cartItem.ConvertToModel(item);

                return Ok(cartItemModel);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CartItemModel>> AddCartItem([FromBody]AddCartItemModel addCartItemModel)
        {
            try
            {
                var newCartItem = await _cartRepository.AddCartItem(addCartItemModel);

                if (newCartItem is null)
                {
                    return NoContent();
                }

                var item = await _itemRepository.GetItem(newCartItem.ItemId);

                if (item is null)
                {
                    throw new Exception($"Something went wrong, can not retrieve the product (itemId:({addCartItemModel.ItemId})");
                }

                var newCartItemModel = newCartItem.ConvertToModel(item);

                return CreatedAtAction( nameof(GetCartItem), new { id = newCartItemModel.Id}, newCartItemModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CartItemModel>> RemoveCartItem(int id)
        {
            try
            {
                var cartItem = await _cartRepository.RemoveCartItem(id);
                if (cartItem == null)
                {
                    return NotFound();
                }

                var item = await _itemRepository.GetItem(cartItem.ItemId);

                if (item == null)
                {
                    return NotFound();
                }
                var cartItemModel = cartItem.ConvertToModel(item);

                return Ok(cartItemModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<CartItemModel>> UpdateQuantity(int id, UpdateCartItemQuantityModel updateModel)
        {
            try
            {
                var cartItem = await this._cartRepository.UpdateCartItemQuantity(id, updateModel);
                if (cartItem == null)
                {
                    return NotFound();
                }

                var item = await this._itemRepository.GetItem(cartItem.ItemId);
                var cartItemModel = cartItem.ConvertToModel(item);
                return Ok(cartItemModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
}
}
