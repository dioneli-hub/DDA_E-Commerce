using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.Repositories.CartRepository;
using DDA.BusinessLogic.Repositories.ItemRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
}
}
