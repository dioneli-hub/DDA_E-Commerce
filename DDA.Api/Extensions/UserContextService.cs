﻿using DDA.BusinessLogic.UserContext;
using System.Security.Principal;

namespace DDA.Api.Extensions
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public UserContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        private IIdentity? UserIdentity => _contextAccessor.HttpContext?.User.Identity;

        public int GetCurrentUserId()
        {
            var nameClaim = UserIdentity?.Name;
            if (!string.IsNullOrEmpty(nameClaim) && int.TryParse(nameClaim, out var userId))
            {
                return userId;
            }

            throw new ApplicationException("User is not authenticated!");
        }

        public bool IsUserLoggedIn()
        {
            return UserIdentity!.IsAuthenticated;
        }
    }
}

