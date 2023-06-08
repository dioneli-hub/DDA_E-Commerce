﻿using DDA.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.Services.UserService
{
    public interface IUserService
    {
        //public int GetCurrentUserId();
        Task<UserModel> Register(RegisterUserModel registerUserModel);
    }
}
