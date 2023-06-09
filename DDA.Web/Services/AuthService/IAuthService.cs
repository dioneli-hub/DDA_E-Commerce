using DDA.ApiModels;
using DDA.BusinessLogic.AuthSecurityManagers.Models;

namespace DDA.Web.Services.AuthService
{
    public interface IAuthService
    {
        Task<TokenModel> Login(AuthModel authModel);
        Task<bool> ChangePassword(ChangePasswordModel changePasswordModel);
        //Task<UserModel> GetAuthenticatedUser();
        Task<bool> IsAuthenticated();
    }
}
