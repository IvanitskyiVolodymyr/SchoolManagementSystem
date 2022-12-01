using Application.Interfaces;
using Common.Dtos.Grades;
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
    }
}
