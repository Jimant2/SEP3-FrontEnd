using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEnd.Models

{
    public class User
    {

        public User(string username, string password, string email, string role, int securityLevel, int id)
        {
            Username = username;
            Password = password;
            this.email = email;
            Role = role;
            SecurityLevel = securityLevel;
            Id = id;
        }

        public User()
        {
        }


        public int Id;
        public string Username { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public string Role { get; set; }
        public int SecurityLevel { get; set; }

    }
}
