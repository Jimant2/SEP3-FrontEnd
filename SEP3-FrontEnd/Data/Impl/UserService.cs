using SEP3_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEP3_FrontEnd.Authentication;
using System.Net;
using System.Net.Http;
using System.Text.Json;


namespace SEP3_FrontEnd.Data
{
    public class UserService : IUserService
    {
        HttpClient client;

        public UserService()
        {
            client = new HttpClient();
        }

        public async Task<User> ValidateUser(string username, string password)
        {
            User user = new User
            {
                SecurityLevel = 2
            };
            Console.WriteLine("auth set");
                return user;
            
       
        }
    }
}

