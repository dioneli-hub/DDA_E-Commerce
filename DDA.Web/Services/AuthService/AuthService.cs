using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DDA.ApiModels;
using DDA.BusinessLogic.AuthSecurityManagers.Models;

namespace DDA.Web.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TokenModel> Login(AuthModel authModel)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<AuthModel>("api/Auth/login", authModel);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode is System.Net.HttpStatusCode.NoContent)
                    {
                        return default(TokenModel);
                    }

                    return await response.Content.ReadFromJsonAsync<TokenModel>();
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

        public async Task<bool> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Auth/change-password", changePasswordModel.Password);
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        //public async Task<UserModel> GetAuthenticatedUser()
        //{
        //    var response = await _httpClient.GetAsync($"api/Auth");

        //    try
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        //            {
        //                return default(UserModel);
        //            }
        //            return await response.Content.ReadFromJsonAsync<UserModel>();
        //        }

        //        else
        //        {
        //            Console.WriteLine("Catch AuthService code is not success");
        //            return null;
        //            //var message = await response.Content.ReadAsStringAsync();
        //            //throw new Exception(message);
        //        }
        //    }

        //    catch (Exception)
        //    {
        //        Console.WriteLine("Catch AuthService.GetAUthUser()");
        //        return null;
        //    }
        //}

        public async Task<bool> IsAuthenticated()
        {
            var response = await _httpClient.GetAsync($"api/Auth/IsAuthenticated");

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
                }

                else
                {
                    Console.WriteLine("Something went wrong in IsAuthenticated");
                    Console.WriteLine(await response.Content.ReadFromJsonAsync<bool>());
                    throw new Exception();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Catch AuthService.IsAuthenticated");
                throw new Exception(e.Message);

            }
        }
    }
}
