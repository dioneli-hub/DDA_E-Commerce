using DDA.BusinessLogic.AuthSecurityManagers.Models;


namespace DDA.BusinessLogic.AuthSecurityManagers.Contracts
{
    public interface IHashManager
    {
        HashModel Generate(string password);
        byte[] HashPassword(string password, byte[] salt);
    }
}
