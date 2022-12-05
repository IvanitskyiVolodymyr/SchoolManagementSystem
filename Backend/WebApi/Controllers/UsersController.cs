using Application.Interfaces;
using Common.Dtos.Users;
using Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserDto>> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpGet("GetUserByEmail")]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            return Ok(user);
        }

        [HttpPut("UpdateUser")]
        public async Task UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUser(user);
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<UserDto>> CreateStudent([FromBody] CreateStudentDto student)
        {
            return Ok(await _userService.CreateStudent(student));
        }

        [HttpPost("CreateParentWithChildrenIds")]
        public async Task<ActionResult<ResponseParentDto>> CreateParentWithChildrenIds([FromBody] CreateParentDto parent)
        {
            return Ok(await _userService.CreateParentWithChildrenIds(parent));
        }

        [HttpPost("CreateTeacher")]
        public async Task<ActionResult<UserDto>> CreateTeacher([FromBody] CreateTeacherDto teacher)
        {
            return Ok(await _userService.CreateTeacher(teacher));
        }
    }
}
