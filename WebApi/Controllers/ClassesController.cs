using Application.Interfaces;
using Common.Dtos.Class;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpPost("CreateClass")]
        public async Task<ActionResult<int>> CreateStudent([FromBody] InsertClassDto classDto)
        {
            return Ok(await _classService.CreateClass(classDto));
        }
    }
}
