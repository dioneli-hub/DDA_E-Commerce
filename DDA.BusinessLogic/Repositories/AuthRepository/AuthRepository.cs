using DDA.BusinessLogic.AuthManagers;
using DDA.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DDA.BusinessLogic.Repositories.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;

        public AuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public TokenModel Authenticate(string email, string password)
        {
            var user = _dataContext.Users.SingleOrDefault(x => x.Email == email);

            if (user == null || !PasswordManager.Verify(user, password))
            {
                throw new ApplicationException("Incorrect email or password.");
            }
            return JwtManager.GenerateJwtToken(user.Id);
        }
    }
}
