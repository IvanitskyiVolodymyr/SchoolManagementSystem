using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet("GetUserById")]
        public async Task<ActionResult<User>> UserInfo(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task CreateUser([FromBody] User user) 
        {
            await _userRepository.InsertUser(user);
        }

        [HttpPut("UpdateUser")]
        public async Task UpdateUser([FromBody] User user)
        {
            await _userRepository.UpdateUser(user);
        }

        [HttpDelete("DeleteUser")]
        public async Task DeleteUser(int userId)
        {
            await _userRepository.DeleteUser(userId);
        }
    }
}
