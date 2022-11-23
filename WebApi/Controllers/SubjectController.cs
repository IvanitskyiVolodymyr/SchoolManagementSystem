using Application.Interfaces;
using Common.Dtos.Class;
using Common.Dtos.Subject;
using Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("CreateSubject")]
        public async Task<ActionResult<int>> CreateSubject([FromBody] InsertSubjectDto subject)
        {
            return Ok(await _subjectService.CreateSubject(subject));
        }

        [HttpPost("CreateSubjects")]
        public async Task<ActionResult<List<int>>> CreateSubjects([FromBody] List<InsertSubjectDto> subjects)
        {
            return Ok(await _subjectService.CreateSubjects(subjects));
        }

        [HttpGet("GetAllSubjects")]
        public async Task<ActionResult<List<Subject>>> GetAllSubjects()
        {
            return Ok(await _subjectService.GetAllSubjects());
        }
    }
}
