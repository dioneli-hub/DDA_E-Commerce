using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DDA.ApiModels;
using DDA.BusinessLogic.AuthManagers;

namespace DDA.BusinessLogic.Services.AuthService
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
    }
}
