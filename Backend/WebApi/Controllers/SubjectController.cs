using Application.Interfaces;
using Common.Dtos.Subject;
using Common.Dtos.SubjectTeacher;
using Domain.Core.Entities;
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

        [HttpPost]
        public async Task<ActionResult<int>> CreateSubject([FromBody] InsertSubjectDto subject)
        {
            return Ok(await _subjectService.CreateSubject(subject));
        }

        [HttpPost("subjects")]
        public async Task<ActionResult<List<int>>> CreateSubjects([FromBody] List<InsertSubjectDto> subjects)
        {
            return Ok(await _subjectService.CreateSubjects(subjects));
        }

        [HttpPost("add-teacher")]
        public async Task<ActionResult<int>> AddTeacherToSubject([FromBody] InsertSubjectTeacherDto subjectTeacherDto)
        {
            return Ok(await _subjectService.AddTeacherToSubject(subjectTeacherDto));
        }

        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetAllSubjects()
        {
            return Ok(await _subjectService.GetAllSubjects());
        }
    }
}
