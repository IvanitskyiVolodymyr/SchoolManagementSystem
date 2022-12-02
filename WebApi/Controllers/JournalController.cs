using Application.Interfaces;
using Common.Dtos.ClassSubjectGrade;
using Common.Dtos.Grades;
using Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpGet("GetAllGradesWithSubjectsForStudent")]
        public async Task<ActionResult<IEnumerable<SubjectGradesDto>>> GetAllGradesWithSubjectsForStudent(int studentId)
        {
            return Ok(await _journalService.GetAllGradesWithSubjectsForStudent(studentId));
        }

        [HttpGet("GetAllFinalGradesByClassSubjectId")]
        public async Task<ActionResult<IEnumerable<ClassSubjectGrade>>> GetAllFinalGradesByClassSubjectId(int studentId, int classSubjectId)
        {
            return Ok(await _journalService.GetAllFinalGradesByClassSubjectId(studentId, classSubjectId));
        }

        [HttpGet("GetAllFinalGradesByClassId")]
        public async Task<ActionResult<IEnumerable<ClassSubjectGrade>>> GetAllFinalGradesByClassId(int studentId, int classId)
        {
            return Ok(await _journalService.GetAllFinalGradesByClassId(studentId, classId));
        }

        [HttpPost("InsertClassSubjectGrade")]
        public async Task<ActionResult<int>> InsertClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto)
        {
            return Ok(await _journalService.InsertClassSubjectGrade(subjectGradeDto));
        }

        [HttpPut("UpdateClassSubjectGrade")]
        public async Task<ActionResult<int>> UpdateClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto)
        {
            return Ok(await _journalService.UpdateClassSubjectGrade(subjectGradeDto));
        }
    }
}
