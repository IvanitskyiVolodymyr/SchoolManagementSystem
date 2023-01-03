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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("get-class-id")]
        public async Task<ActionResult<int>> GetClassIdByStudentId(int studentId)
        {
            return Ok(await _userService.GetClassIdByStudentId(studentId));
        }

        [Authorize]
        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmail(email);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet("user-with-role")]
        public async Task<ActionResult<EntityWithRoleDto>> GetEntityIdWithRoleByUserId(int userId, int roleId)
        {
            return Ok(await _userService.GetEntityIdWithRoleByUserId(userId, roleId));
        } 

        [HttpPut]
        public async Task UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUser(user);
        }

        [HttpPost("students")]
        public async Task<ActionResult<UserDto>> CreateStudent([FromBody] CreateStudentDto student)
        {
            return Ok(await _userService.CreateStudent(student));
        }

        [HttpPost("parents")]
        public async Task<ActionResult<ResponseParentDto>> CreateParentWithChildrenIds([FromBody] CreateParentDto parent)
        {
            return Ok(await _userService.CreateParentWithChildrenIds(parent));
        }

        [HttpPost("teachers")]
        public async Task<ActionResult<UserDto>> CreateTeacher([FromBody] CreateTeacherDto teacher)
        {
            return Ok(await _userService.CreateTeacher(teacher));
        }
    }
}
