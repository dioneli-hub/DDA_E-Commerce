using DDA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userId);

    }
}
