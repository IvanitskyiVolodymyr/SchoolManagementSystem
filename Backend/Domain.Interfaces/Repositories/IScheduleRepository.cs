using Common.Dtos.Schedule;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IScheduleRepository
    {
        Task InsertScheduleRange(IList<InsertScheduleDto> scheduleDto);
        Task<int> InsertSchedule(InsertScheduleDto scheduleDto);
        Task<int> UpdateSchedule(Schedule schedule);
        Task<IEnumerable<ScheduleWithSubject>> GetScheduleForStudentByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId);
        Task<IEnumerable<ScheduleWithClassSubjectDto>> GetScheduleForTeacherByPeriod(DateTime startDateTime, DateTime endDateTime, int teacherId);
        Task<bool> CheckIsTimeFrameFree(DateTime startDateTime, DateTime endDateTime, int classSubjectId);
    }
}
