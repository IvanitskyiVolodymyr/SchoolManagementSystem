using Application.Interfaces;
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

        [HttpGet("GetScheduleForClassByPeriod")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetScheduleForClassByPeriod(DateTime startTime, DateTime endTime, int classId)
        {
            return Ok(await _scheduleService.GetScheduleForClassByPeriod(startTime, endTime, classId));
        }

        [HttpGet("GetScheduleForTeacherByPeriod")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetScheduleForTeacherByPeriod(DateTime startTime, DateTime endTime, int teacherId)
        {
            return Ok(await _scheduleService.GetScheduleForTeacherByPeriod(startTime, endTime, teacherId));
        }
    }
}
