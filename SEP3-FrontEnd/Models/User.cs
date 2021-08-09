using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEnd.Models

{
    public class User
    {

        public User(string userName, string password, string email, string role, int securityLevel, int id)
        {
            UserName = userName;
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
        public string UserName { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public string Role { get; set; }
        public int SecurityLevel { get; set; }

        public override string ToString()
        {
            return base.ToString() + ":" + UserName.ToString() + ":" + Password.ToString() + ":" + email.ToString() + ":" + Role.ToString() + ":" + SecurityLevel.ToString();
        }

    }
}
