using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.Repositories.ItemRepository;
using DDA.BusinessLogic.Repositories.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserModel>> RegisterUser([FromBody]RegisterUserModel registerUserModel)
        {
            try
            {
                var newUser = await _userRepository.RegisterUser(registerUserModel);

                if (newUser is null)
                {
                    return NoContent();
                }

                var newUserModel = newUser.ConvertToModel();

                return Ok(newUserModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpGet]
        [Route("{userId}/GetUserCart")]
        public async Task<ActionResult<CartModel>> GetUserCart(int userId)
        {
            try
            {
                var cart = await _userRepository.GetUserCart(userId);

                if (cart is null)
                {
                    return NoContent();
                }
                var cartModel = cart.ConvertToModel;
                return Ok(cartModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


    }
}
