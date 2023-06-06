﻿using DDA.ApiModels;
using DDA.BusinessLogic.UserContext;
using System.Net.Http;
using System.Net.Http.Json;

namespace DDA.BusinessLogic.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //private readonly IUserContextService _userContextService;
        public UserService()//IUserContextService userContextService
        {
            //_userContextService = userContextService;
        }
        public int GetCurrentUserId()
        {
            return 1;//_userContextService.GetCurrentUserId();
        }

        public async Task<UserModel> Register(RegisterUserModel registerUserModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<RegisterUserModel>("api/User", registerUserModel);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is System.Net.HttpStatusCode.NoContent)
                    {
                        return default(UserModel);
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
