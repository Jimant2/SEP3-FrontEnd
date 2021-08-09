using SEP3_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP3_FrontEnd.Data.Impl
{
    public class UserService : IUserService
    {
        private const string uri = "http://localhost:5000/user";
        private readonly HttpClient client;

        JsonSerializerOptions  serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public UserService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            client = new HttpClient(clientHandler);
        }


        public async Task RegisterUser(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user, serializeOptions);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri, content);
        }

      

        public async Task<User> SearchUser(string searchText)
        {
            HttpResponseMessage response = await client.GetAsync(uri + $"searchText={searchText}");

            searchText = await response.Content.ReadAsStringAsync();
            User user = JsonSerializer.Deserialize<User>(searchText, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });
            return user;
        }

        public async Task UpdateUser(User user, string password)
        {
            var userAsJson = JsonSerializer.Serialize(user, serializeOptions);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PutAsync(uri + "password=" + password, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
        }

      

        public async Task<User> ValidateUser(string userName, string password)
        {
            HttpResponseMessage response = await client.GetAsync(uri + $"username={userName}&password={@password}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            string result = await response.Content.ReadAsStringAsync();
            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });
            return user;
        }
    }
}

