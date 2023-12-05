using DDA.BusinessLogic.AuthSecurityManagers.Models;
using DDA.Domain;

namespace DDA.BusinessLogic.AuthSecurityManagers.Contracts
{
    public interface IAuthManager
    {
        Task<ServiceResponse<string>> Authenticate(string email, string password);
    }
}
