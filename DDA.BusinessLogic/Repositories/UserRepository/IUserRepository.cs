using DDA.Domain;
using DDA.ApiModels;

namespace DDA.BusinessLogic.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);
        Task<User> RegisterUser(RegisterUserModel registerUserModel);
        Task<Cart> GetUserCart(int userId);
    }
}
