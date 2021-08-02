using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEnd.Models

{
    public class User
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public string Role { get; set; }
        public int SecurityLevel { get; set; }

     
    }
}
