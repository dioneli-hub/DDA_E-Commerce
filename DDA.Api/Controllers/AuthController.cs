using DDA.ApiModels;
using DDA.BusinessLogic.AuthManagers;
using DDA.BusinessLogic.Repositories.AuthRepository;
using DDA.BusinessLogic.Repositories.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;

        public AuthController(IAuthRepository authRepository,
            IUserRepository userRepository)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserModel>> AuthenticatedUser()
        {
            var user = await _userRepository.GetUser(this.CurrentUserId);
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenModel>> Authenticate(AuthModel model)
        {
            var token = _authRepository.Authenticate(model.Email, model.Password);
            return Ok(token);
        }

        public int CurrentUserId
        {
            get
            {
                var nameClaim = HttpContext.User.Identity!.Name;
                return int.Parse(nameClaim!);
            }
        }
    }
}
