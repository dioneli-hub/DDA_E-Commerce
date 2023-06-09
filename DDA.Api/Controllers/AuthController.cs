using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.AuthSecurityManagers.Contracts;
using DDA.BusinessLogic.AuthSecurityManagers.Models;
using DDA.BusinessLogic.Repositories.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IAuthManager _authManager;

        public AuthController(
            IUserRepository userRepository,
            IAuthManager authManager)
        {
            _userRepository = userRepository;
            _authManager = authManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserModel>> AuthenticatedUser()
        {
            var user = await _userRepository.GetUser(this.CurrentUserId);
            var userModel = user.ConvertToModel();
            return Ok(userModel);
        }

        [HttpGet]
        [Route("IsAuthenticated")]
        public async Task<ActionResult<bool>> IsAuthenticated()
        {
            return HttpContext.User.Identity.IsAuthenticated ? Ok(true) : Ok(false);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenModel>> Authenticate(AuthModel model)
        {
            var token = await _authManager.Authenticate(model.Email, model.Password);
            return Ok(token);
        }

        public int CurrentUserId
        {
            get
            {
                Console.WriteLine($"!!!!!!!!!!!!!!!!!!!NAME CLAIM {HttpContext.User.Identity!.Name}");
                var nameClaim = HttpContext.User.Identity!.Name;
                return int.Parse(nameClaim!);
            }
        }
    }
}
