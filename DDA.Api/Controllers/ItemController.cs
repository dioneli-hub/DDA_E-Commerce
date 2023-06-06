using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.Repositories.ItemRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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
                    var itemCategory = await _itemRepository.GetCategory(item.CategoryId);
                    var itemModel = item.ConvertToModel(itemCategory);
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
    }
}
