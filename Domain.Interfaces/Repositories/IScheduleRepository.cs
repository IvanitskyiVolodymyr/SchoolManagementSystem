using Common.Dtos.Schedule;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IScheduleRepository
    {
        Task InsertScheduleRange(IList<InsertScheduleDto> scheduleDto);
        Task<int> InsertSchedule(InsertScheduleDto scheduleDto);
        Task<int> UpdateSchedule(Schedule schedule);
        Task<IEnumerable<Schedule>> GetScheduleForClassByPeriod(DateTime startDateTime, DateTime endDateTime, int classId);
        Task<IEnumerable<Schedule>> GetScheduleForTeacherByPeriod(DateTime startDateTime, DateTime endDateTime, int teacherId);
    }
}
