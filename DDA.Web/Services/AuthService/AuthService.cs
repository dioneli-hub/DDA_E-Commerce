using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using DDA.ApiModels;
using DDA.BusinessLogic.AuthSecurityManagers.Models;
using DDA.Domain;
using static System.Net.WebRequestMethods;

namespace DDA.Web.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse<string>> Login(AuthModel authModel)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Auth/login", authModel);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<bool>> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Auth/change-password", changePasswordModel.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
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
