using Microsoft.EntityFrameworkCore;
using DDA.BusinessLogic.AuthSecurityManagers.Models;
using DDA.BusinessLogic.AuthSecurityManagers.Contracts;
using DDA.DataAccess;
using DDA.Domain;

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

        public async Task<ServiceResponse<string>> Authenticate(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found :(";
            }
            else if (!await _passwordVerifier.Verify(user.Id, password))
            {
                response.Success = false;
                response.Message = "Incorrect password. Please, try again.";
            }
            else 
            {
                response.Data = _jwtManager.GenerateJwtToken(user.Id);
            }
            return response;
        }

        
    }
}
