using Microsoft.EntityFrameworkCore;
using DDA.BusinessLogic.AuthSecurityManagers.Models;
using DDA.BusinessLogic.AuthSecurityManagers.Contracts;
using DDA.DataAccess;

namespace DDA.BusinessLogic.AuthSecurityManagers
{
    public class AuthManager : IAuthManager
    {
        private readonly DataContext _context;
        private readonly IJwtManager _jwtManager;
        private readonly IPasswordVerifier _passwordVerifier;

        public AuthManager(DataContext context,
            IJwtManager jwtManager,
            IPasswordVerifier passwordVerifier)
        {
            _context = context;
            _jwtManager = jwtManager;
            _passwordVerifier = passwordVerifier;
        }

        public async Task<TokenModel> Authenticate(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null || !await _passwordVerifier.Verify(user.Id, password))
            {
                throw new ApplicationException("Incorrect email or password.");
            }

            return _jwtManager.GenerateJwtToken(user.Id);
        }

        
    }
}
