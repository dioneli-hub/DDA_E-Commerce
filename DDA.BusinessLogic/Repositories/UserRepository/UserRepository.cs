using DDA.ApiModels;
using DDA.BusinessLogic.AuthManagers;
using DDA.DataAccess;
using DDA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User> GetUser(int userId)
        {
            var user = await _dataContext.Users.FindAsync(userId);
            return user;
        }

        public async Task<User> RegisterUser(RegisterUserModel registerUserModel)
        {
            if (await UserAlreadyRegistered(registerUserModel.Email) == false)
            {
                var hashModel = HashManager.Generate(registerUserModel.Password);

                var user = new User{
                    Name = registerUserModel.Name,
                    Email = registerUserModel.Email,
                    PasswordHash = Convert.ToBase64String(hashModel.Hash),
                    SaltHash = Convert.ToBase64String(hashModel.Salt),
                };

                if (user != null)
                {
                    var result = await _dataContext.Users.AddAsync(user);
                    await _dataContext.SaveChangesAsync();
                    return result.Entity;
                }
            }

            return null;
        }

        //private UserAlreadyRegistered
    }
}

