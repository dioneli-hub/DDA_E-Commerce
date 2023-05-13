using DDA.BusinessLogic.AuthManagers;

namespace DDA.BusinessLogic.Repositories.AuthRepository
{
    public interface IAuthRepository
    {
        public TokenModel Authenticate(string email, string password);
    }
}
