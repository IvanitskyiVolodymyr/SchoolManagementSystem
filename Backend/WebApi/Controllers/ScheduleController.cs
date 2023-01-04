using Application.Interfaces;
using Common.Dtos.Attendance;
using Common.Dtos.Schedule;
using Domain.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("schedules")]
        public async Task<ActionResult> InsertScheduleRange([FromBody] IList<InsertScheduleDto> scheduleRange)
        {
            await _scheduleService.InsertScheduleRange(scheduleRange);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertSchedule([FromBody] InsertScheduleDto scheduleDto)
        {
            return Ok(await _scheduleService.InsertSchedule(scheduleDto));
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateSchedule([FromBody] Schedule schedule)
        {
            return Ok(await _scheduleService.UpdateSchedule(schedule));
        }

        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<ScheduleWithSubject>>> GetScheduleForStudentByPeriod(DateTime startTime, DateTime endTime, int studentId)
        {
            return Ok(await _scheduleService.GetScheduleForStudentByPeriod(startTime, endTime, studentId));
        }

        [HttpGet("teachers")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetScheduleForTeacherByPeriod(DateTime startTime, DateTime endTime, int teacherId)
        {
            return Ok(await _scheduleService.GetScheduleForTeacherByPeriod(startTime, endTime, teacherId));
        }

        [HttpPost("attendances")]
        public async Task<ActionResult<List<int>>> InsertAttendances(IList<InsertAttendanceDto> attendances, int scheduleId)
        {
            return Ok(await _scheduleService.InsertAttendances(attendances, scheduleId));
        }

        [HttpGet("students/schedules-with-attendances")]
        public async Task<ActionResult<IEnumerable<ScheduleAttendanceDto>>> GetScheduleForStudentWithAttendancesByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId)
        {
            return Ok(await _scheduleService.GetScheduleForStudentWithAttendancesByPeriod(startDateTime, endDateTime, studentId));
        }

        [HttpGet("attendances")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendancesForClassSubjectByPeriod(DateTime startDateTime, DateTime endDateTime, int classSubjectId)
        {
            return Ok(await _scheduleService.GetAttendancesForClassSubjectByPeriod(startDateTime, endDateTime, classSubjectId));
        }

        [HttpPut("attendances")]
        public async Task<ActionResult<int>> UpdateAttendance(UpdateAttendanceDto attendance)
        {
            return Ok(await _scheduleService.UpdateAttendance(attendance));
        }
    }
}
