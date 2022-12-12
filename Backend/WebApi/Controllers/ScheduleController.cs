using Application.Interfaces;
using Common.Dtos.Attendance;
using Common.Dtos.Schedule;
using Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("InsertScheduleRange")]
        public async Task<ActionResult> InsertScheduleRange([FromBody] IList<InsertScheduleDto> scheduleRange)
        {
            await _scheduleService.InsertScheduleRange(scheduleRange);
            return Ok();
        }

        [HttpPost("InsertSchedule")]
        public async Task<ActionResult<int>> InsertSchedule([FromBody] InsertScheduleDto scheduleDto)
        {
            return Ok(await _scheduleService.InsertSchedule(scheduleDto));
        }

        [HttpPut("UpdateSchedule")]
        public async Task<ActionResult<int>> UpdateSchedule([FromBody] Schedule schedule)
        {
            return Ok(await _scheduleService.UpdateSchedule(schedule));
        }

        [HttpGet("GetScheduleForStudentByPeriod")]
        public async Task<ActionResult<IEnumerable<ScheduleWithSubject>>> GetScheduleForStudentByPeriod(DateTime startTime, DateTime endTime, int studentId)
        {
            return Ok(await _scheduleService.GetScheduleForStudentByPeriod(startTime, endTime, studentId));
        }

        [HttpGet("GetScheduleForTeacherByPeriod")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetScheduleForTeacherByPeriod(DateTime startTime, DateTime endTime, int teacherId)
        {
            return Ok(await _scheduleService.GetScheduleForTeacherByPeriod(startTime, endTime, teacherId));
        }

        [HttpPost("InsertAttendances")]
        public async Task<ActionResult<List<int>>> InsertAttendances(IList<InsertAttendanceDto> attendances, int scheduleId)
        {
            return Ok(await _scheduleService.InsertAttendances(attendances, scheduleId));
        }

        [HttpGet("GetScheduleForStudentWithAttendancesByPeriod")]
        public async Task<ActionResult<IEnumerable<ScheduleAttendanceDto>>> GetScheduleForStudentWithAttendancesByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId)
        {
            return Ok(await _scheduleService.GetScheduleForStudentWithAttendancesByPeriod(startDateTime, endDateTime, studentId));
        }

        [HttpGet("GetAttendancesForClassSubjectByPeriod")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendancesForClassSubjectByPeriod(DateTime startDateTime, DateTime endDateTime, int classSubjectId)
        {
            return Ok(await _scheduleService.GetAttendancesForClassSubjectByPeriod(startDateTime, endDateTime, classSubjectId));
        }

        [HttpPut("UpdateAttendance")]
        public async Task<ActionResult<int>> UpdateAttendance(UpdateAttendanceDto attendance)
        {
            return Ok(await _scheduleService.UpdateAttendance(attendance));
        }
    }
}
