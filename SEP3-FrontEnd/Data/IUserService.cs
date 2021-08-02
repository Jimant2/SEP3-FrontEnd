using SEP3_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEnd.Data
{
   public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}
