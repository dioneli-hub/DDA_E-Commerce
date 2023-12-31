﻿
using DDA.Api.Extensions;
using DDA.ApiModels;
using DDA.BusinessLogic.AuthSecurityManagers.Contracts;
using DDA.BusinessLogic.AuthSecurityManagers.Models;
using DDA.BusinessLogic.Repositories.UserRepository;
using DDA.BusinessLogic.UserContext;
using DDA.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DDA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IAuthManager _authManager;
        private readonly IUserContextService _userContextService;

        public AuthController(
            IUserRepository userRepository,
            IAuthManager authManager,
            IUserContextService userContextService)
        {
            _userRepository = userRepository;
            _authManager = authManager;
            _userContextService = userContextService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserModel>> AuthenticatedUser()
        {
            var user = await _userRepository.GetUser(_userContextService.GetCurrentUserId());
            var userModel = user.ConvertToModel();
            return Ok(userModel);
        }

        [HttpGet]
        [Route("IsAuthenticated")]
        public async Task<ActionResult<bool>> IsAuthenticated()
        {
            return _userContextService.IsUserLoggedIn() ? Ok(true) : Ok(false);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Authenticate(AuthModel model)
        {
            var response = await _authManager.Authenticate(model.Email, model.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("change-password")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var response = await _userRepository.ChangePassword(int.Parse(userId), newPassword);

            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
