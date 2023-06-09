using DDA.ApiModels;
using DDA.BusinessLogic.AuthSecurityManagers.Contracts;
using DDA.DataAccess;
using DDA.Domain;
using Microsoft.EntityFrameworkCore;

namespace DDA.BusinessLogic.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IHashManager _hashManager;

        public UserRepository(DataContext dataContext,
            IHashManager hashManager)
        {
            _dataContext = dataContext;
            _hashManager = hashManager;
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
                var hashModel = _hashManager.Generate(registerUserModel.Password);

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

        public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        {
            var user = await _dataContext.Users.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found :("
                };
            }

                var hashModel = _hashManager.Generate(newPassword);



            user.PasswordHash = Convert.ToBase64String(hashModel.Hash);
            user.SaltHash = Convert.ToBase64String(hashModel.Salt);

            await _dataContext.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Data = true,
                Message = "The password has been changed successfully!"
            };
        }
    }
}

