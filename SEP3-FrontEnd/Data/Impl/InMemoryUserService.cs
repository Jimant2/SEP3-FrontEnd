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
                    UserName = "Bill",
                    Password = "12345",
                    Role = "User",
                    SecurityLevel = 2
                }
            }.ToList();


        }

        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
                if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Equals(password))
            {
                throw new Exception("Incorrect password");
            }
            return first;
        }
    }
}

