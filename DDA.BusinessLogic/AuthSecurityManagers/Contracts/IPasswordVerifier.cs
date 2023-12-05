using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.AuthSecurityManagers.Contracts
{
    public interface IPasswordVerifier
    {
        Task<bool> Verify(int userId, string password);
    }
}
