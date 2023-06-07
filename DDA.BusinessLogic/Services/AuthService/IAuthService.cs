using DDA.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.Services.AuthService
{
    public interface IAuthService
    {
        Task<UserModel> Login(AuthModel authModel);
    }
}
