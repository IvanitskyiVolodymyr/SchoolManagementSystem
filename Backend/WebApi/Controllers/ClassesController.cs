using Application.Interfaces;
using Common.Dtos.Class;
using Common.Dtos.ClassSubject;
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

        [HttpPost]
        public async Task<ActionResult<int>> CreateClass([FromBody] InsertClassDto classDto)
        {
            return Ok(await _classService.CreateClass(classDto));
        }

        [HttpPost("classes")]
        public async Task<ActionResult<List<int>>> CreateClasses([FromBody] List<InsertClassDto> classesDto)
        {
            return Ok(await _classService.CreateClasses(classesDto));
        }

        [HttpPost("add-subject")]
        public async Task<ActionResult<int>> AddSubjectToClass([FromBody] InsertClassSubjectDto classSubjectDto)
        {
            return Ok(await _classService.AddSubjectToClass(classSubjectDto));
        }

        [HttpPost("add-subjects")]
        public async Task<ActionResult<List<int>>> AddSubjectsToClass([FromBody] List<InsertClassSubjectDto> classSubjects)
        {
            return Ok(await _classService.AddSubjectsToClass(classSubjects));
        }
    }
}
