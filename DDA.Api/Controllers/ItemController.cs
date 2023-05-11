using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.Repositories.ItemRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModel>>> GetItems()
        {
            try
            {
                var items = await _itemRepository.GetItems();
                var categories = await _itemRepository.GetCategories();

                if (items == null || categories == null) 
                {
                    return NotFound();
                }

                else
                {
                    var itemModels = items.ConvertToModel(categories);

                    return Ok(itemModels);
                }
            }

            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Can not retrieve data from database.");
            }
        }
    }
}
