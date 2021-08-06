using SEP3_FrontEndWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP3_FrontEndWEBAPI.Data.Impl
{
    public class UserService : IUserService
    {
        private string uri = "http://localhost:8080";
        private HttpClient client;

        public UserService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            client = new HttpClient(clientHandler);
        }


       
    


        public async Task<User> UpdateUser(User user, string password)
        {
            User valid = await ValidateUser(user.UserName, password);
            if (valid == null)
            {
                throw new Exception($@"Error: Password or username incorrect");
            }

            string UserAsJson = JsonSerializer.Serialize(user);
            Console.WriteLine(UserAsJson);
            HttpContent content = new StringContent(
                UserAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response =
                await client.PutAsync(uri + $"/UpdateUser", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error");
            }

            string result = await response.Content.ReadAsStringAsync();
            User updateUser = JsonSerializer.Deserialize<User>(result,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return updateUser;
        }

        public async Task<User> SearchUser(string searchText)
        {
            HttpResponseMessage response = await client.GetAsync(uri + $"searchText{searchText}");

            searchText = await response.Content.ReadAsStringAsync();
            User user = JsonSerializer.Deserialize<User>(searchText, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            });
            return user;
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            HttpResponseMessage response =
                await client.GetAsync(uri + "/ValidateUser" + $"Username={userName}&Password={@password}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error");
            }
            string result = await response.Content.ReadAsStringAsync();
            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            return user;
        }

        public async Task<User> RegisterUser(User user)
        {
            user.SecurityLevel = 2;
            string UserAsJson = JsonSerializer.Serialize(user);
            Console.WriteLine(UserAsJson);
            HttpContent content = new StringContent(
                UserAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/RegisterUser", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error");
            }
            string result = await response.Content.ReadAsStringAsync();
            User userReceived = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy
                = JsonNamingPolicy.CamelCase
            });
            return userReceived;
        }
    }
}

