using Microsoft.AspNetCore.Mvc;
using SEP3_FrontEndWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEndWEBAPI.Controllers
{
    public interface IUserController
    {
        Task<ActionResult<User>> RegisterUser([FromBody] User user);
        Task<ActionResult<User>> ValidateUser([FromQuery] string email, [FromQuery] string password);
        Task<ActionResult<User>> UpdateUser([FromBody] User user, [FromQuery] string password);
    }
}
