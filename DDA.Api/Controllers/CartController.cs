using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.Repositories.CartRepository;
using DDA.BusinessLogic.Repositories.ItemRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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

                if (cartItems == null)
                {
                    return NoContent();
                }

                var items = await _itemRepository.GetItems();

                if (items == null)
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
}
}
