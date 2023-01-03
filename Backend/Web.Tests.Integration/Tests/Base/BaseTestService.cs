using Common.Dtos.Auth;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Web.Tests.Integration.Setup;

namespace Web.Tests.Integration.Tests.Base
{
    public class BaseTestService : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        protected HttpClient Client;
        private readonly CustomWebApplicationFactory<Program>
            _factory;

        public BaseTestService(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            Client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        protected StringContent GetStringContent<T>(T payload)
        {
            return new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
        }

        protected async Task<T> GetResponse<T>(HttpResponseMessage response)
        {
            var contentString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(contentString);
        }

        protected void AddAuthorizationHeader(string accessToken)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        protected async Task<AuthUserDto> SetupUser(LoginDto loginDto)
        {
            var signUpResponse = await Client.PostAsync("api/auth/login", GetStringContent(loginDto));
            var authUser =  await GetResponse<AuthUserDto>(signUpResponse);
            return authUser;
        }
    }
}
