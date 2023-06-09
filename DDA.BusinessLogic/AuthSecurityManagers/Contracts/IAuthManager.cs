using DDA.BusinessLogic.AuthSecurityManagers.Models;

namespace DDA.BusinessLogic.AuthSecurityManagers.Contracts
{
    public interface IAuthManager
    {
        Task<TokenModel> Authenticate(string email, string password);
    }
}
