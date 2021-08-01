using SEP3_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEnd.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    username = "Bill",
                    password = "12345",
                    Role = "User",
                    SecurityLevel = 2
                }
            }.ToList();


        }

        public User ValidateUser(string userName, string Password)
        {
            User first = users.FirstOrDefault(user => user.username.Equals(userName));
                if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Equals(Password))
            {
                throw new Exception("Incorrect password");
            }
            return first;
        }
    }
}

