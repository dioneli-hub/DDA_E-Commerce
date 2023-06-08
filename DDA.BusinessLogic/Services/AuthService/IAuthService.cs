using DDA.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDA.BusinessLogic.AuthManagers;

namespace DDA.BusinessLogic.Services.AuthService
{
    public interface IAuthService
    {
        Task<TokenModel> Login(AuthModel authModel);
    }
}
