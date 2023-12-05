using DDA.ApiModels;
using DDA.BusinessLogic.UserContext;
using System.Net.Http;
using System.Net.Http.Json;

namespace DDA.Web.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //private readonly IUserContextService _userContextService;
        //public UserService(IUserContextService userContextService)
        //{
        //    _userContextService = userContextService;
        //}
        //public int GetCurrentUserId()
        //{
        //    return _userContextService.GetCurrentUserId();
        //}

        public async Task<UserModel> Register(RegisterUserModel registerUserModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/User/register", registerUserModel);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is System.Net.HttpStatusCode.NoContent)
                    {
                        return default;
                    }

                    return await response.Content.ReadFromJsonAsync<UserModel>();
                }

                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status:{response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
