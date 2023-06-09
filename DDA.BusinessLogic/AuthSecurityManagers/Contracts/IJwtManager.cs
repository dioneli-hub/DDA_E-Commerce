using DDA.BusinessLogic.AuthSecurityManagers.Models;

namespace DDA.BusinessLogic.AuthSecurityManagers.Contracts
{
    public interface IJwtManager
    {
        TokenModel GenerateJwtToken(int userId);
        bool IsValidAuthToken(string token);
    }
}
