using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.Repositories.ItemRepository;
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

                if (items == null) 
                {
                    return NotFound();
                }

                else
                {
                    var itemModels = items.ConvertToModel();

                    return Ok(itemModels);
                }
            }

            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Can not retrieve data from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemModel>> GetItem(int id)
        {
            try
            {
                var item = await _itemRepository.GetItem(id);
                

                if (item == null)
                {
                    return BadRequest();
                }

                else
                {
                    var itemModel = item.ConvertToModel();
                    return Ok(itemModel);
                }
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Can not retrieve data from database.");
            }

        }

        [HttpGet]
        [Route(nameof(GetCategories))]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            try
            {
                var categories = await _itemRepository.GetCategories();
                var categoryModels = categories.ConvertToModel();
                return Ok(categoryModels);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }


        [HttpGet]
        [Route("{categoryId}/GetItemsByCategory")]
        public async Task<ActionResult<IEnumerable<ItemModel>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var items = await _itemRepository.GetItemsByCategory(categoryId);
                var itemModels = items.ConvertToModel();
                return Ok(itemModels);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }
    }
}
