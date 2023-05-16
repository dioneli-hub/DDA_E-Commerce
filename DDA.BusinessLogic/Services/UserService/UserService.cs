using DDA.BusinessLogic.UserContext;

namespace DDA.BusinessLogic.Services.UserService
{
    public class UserService : IUserService
    {
        //private readonly IUserContextService _userContextService;
        public UserService()//IUserContextService userContextService
        {
            //_userContextService = userContextService;
        }
        public int GetCurrentUserId()
        {
            return 1;//_userContextService.GetCurrentUserId();
        }
    }
}
