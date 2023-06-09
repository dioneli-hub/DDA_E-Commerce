using DDA.ApiModels;
using DDA.BusinessLogic.AuthSecurityManagers.Models;
using DDA.Domain;

namespace DDA.Web.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(AuthModel authModel);
        Task<ServiceResponse<bool>> ChangePassword(ChangePasswordModel changePasswordModel);
        //Task<UserModel> GetAuthenticatedUser();
        Task<bool> IsAuthenticated();
    }
}
