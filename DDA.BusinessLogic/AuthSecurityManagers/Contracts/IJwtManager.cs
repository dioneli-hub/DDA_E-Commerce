using DDA.BusinessLogic.AuthSecurityManagers.Models;

namespace DDA.BusinessLogic.AuthSecurityManagers.Contracts
{
    public interface IJwtManager
    {
        string GenerateJwtToken(int userId);
        bool IsValidAuthToken(string token);
    }
}
