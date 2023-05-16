using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.Repositories.CartRepository;
using DDA.BusinessLogic.Repositories.ItemRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace DDA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IItemRepository _itemRepository;

        public CartController(ICartRepository cartRepository,
            IItemRepository itemRepository)
        {
            _cartRepository = cartRepository;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        [Route("{userId}/GetUsersCartItems")]
        public async Task<ActionResult<IEnumerable<CartItemModel>>> GetUsersCartItems(int userId)
        {
            try
            {
                var cartItems = await _cartRepository.GetUsersCartItems(userId);

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
        }

        [HttpGet("{id:int}")]
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

                return CreatedAtAction(nameof(GetCartItem), new { id = newCartItemModel.Id}, newCartItemModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
}
}
