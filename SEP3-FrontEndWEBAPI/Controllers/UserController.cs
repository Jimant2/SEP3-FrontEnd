using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_FrontEndWEBAPI.Data;
using SEP3_FrontEndWEBAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace SEP3_FrontEndWEBAPI.Controllers
{



    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase, IUserController
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            try
            {
                User returned = new User();
                    await userService.RegisterUser(user);
                return Ok(returned);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                Console.Write(username + password);
                User valid = await userService.ValidateUser(username, password);
                return Ok(valid);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser([FromBody] User user, [FromQuery] string password)
        {
            try
            {
                User valid = new User();
                await userService.UpdateUser(user, password);
                return Ok(valid);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}
