
using AuthApp.Logic.Interfaces;
using AuthApp.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/User/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult<User>> GetByIdUserAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/User/userName
        [HttpGet("userName/{userName}")]
        public async Task<ActionResult<User>> GetUserByUsernameAsync(string userName)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
