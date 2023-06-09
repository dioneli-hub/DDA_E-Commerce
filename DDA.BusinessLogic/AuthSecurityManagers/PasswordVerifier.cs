using DDA.BusinessLogic.AuthSecurityManagers.Contracts;
using DDA.DataAccess;
using DDA.Domain;
using Microsoft.EntityFrameworkCore;

namespace DDA.BusinessLogic.AuthSecurityManagers
{
    public class PasswordVerifier : IPasswordVerifier
    {
        private readonly DataContext _context;
        private readonly IHashManager _hashManager;

        public PasswordVerifier(DataContext context,
            IHashManager hashManager)
        {
            _context = context;
            _hashManager = hashManager;
        }

        public async Task<bool> Verify(int userId, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            return Verify(user, password);
        }

        private bool Verify(User user, string password)
        {
            var salt = Convert.FromBase64String(user.SaltHash);
            var hash = _hashManager.HashPassword(password, salt);
            var hashedPasswordAsBase64String = Convert.ToBase64String(hash);

            return user.PasswordHash == hashedPasswordAsBase64String;
        }
    }
}
