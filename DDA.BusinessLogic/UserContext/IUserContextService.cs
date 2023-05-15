using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDA.BusinessLogic.UserContext
{
    public interface IUserContextService
    {
        public int GetCurrentUserId();
    }
}
