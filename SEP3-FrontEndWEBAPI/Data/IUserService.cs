using SEP3_FrontEndWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEndWEBAPI.Data
{
   public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
        Task<User> RegisterUser(User user);
        Task<User> UpdateUser(User user, string password);
        Task<User> SearchUser(string searchText);
    }
}
