using Common.Dtos.Schedule;
using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> GetScheduleForClassByPeriod(DateTime startTime, DateTime endTime, int classId);
        Task<IEnumerable<Schedule>> GetScheduleForTeacherByPeriod(DateTime startTime, DateTime endTime, int classId);
        Task<IEnumerable<Schedule>> GenerateSchedule(DateTime from, DateTime to, IList<ScheduleGenerationDto> scheduleGenerationDto);
        Task InsertScheduleRange(IList<InsertScheduleDto> scheduleRange);
        Task<int> InsertSchedule(InsertScheduleDto scheduleDto);
        Task<int> UpdateSchedule(Schedule schedule);
    }
}