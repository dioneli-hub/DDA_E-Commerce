using DDA.ApiModels;
using DDA.BusinessLogic.AuthManagers;
using DDA.DataAccess;
using DDA.Domain;
using Microsoft.EntityFrameworkCore;
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


                if (user is not null)
                {
                    var result = await _dataContext.Users.AddAsync(user);
                    await _dataContext.SaveChangesAsync();

                    var cart = await CreateUserCart(result.Entity.Id);

                    if (cart is not null)
                    {
                        return result.Entity;
                    } 
                }
            }

            return null;
        }

        public async Task<Cart> GetUserCart(int userId)
        {
            var userCart = await (from cart in _dataContext.Carts
                                  where cart.UserId == userId
                                  select cart).SingleOrDefaultAsync();

            return userCart;
        }

        private async Task<Cart> CreateUserCart(int userId)
        {
            var cart = new Cart
            {
                UserId = userId
            };

            var result = await _dataContext.Carts.AddAsync(cart);
            await _dataContext.SaveChangesAsync();
            return result.Entity;

        }

        private async Task<bool> UserAlreadyRegistered(string email)
        {
            return await _dataContext.Users.AnyAsync
                (x => x.Email == email);
        }
    }
}

