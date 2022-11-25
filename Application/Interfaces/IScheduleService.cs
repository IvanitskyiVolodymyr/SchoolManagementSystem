using Common.Dtos.Attendance;
using Common.Dtos.Schedule;
using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> GetScheduleForStudentByPeriod(DateTime startTime, DateTime endTime, int studentId);
        Task<IEnumerable<Schedule>> GetScheduleForTeacherByPeriod(DateTime startTime, DateTime endTime, int teacherId);
        Task<IEnumerable<Schedule>> GenerateSchedule(DateTime from, DateTime to, IList<ScheduleGenerationDto> scheduleGenerationDto);
        Task InsertScheduleRange(IList<InsertScheduleDto> scheduleRange);
        Task<int> InsertSchedule(InsertScheduleDto scheduleDto);
        Task<int> UpdateSchedule(Schedule schedule);
        Task<int> InsertAttendances(IList<InsertAttendanceDto> attendances);
        Task<IEnumerable<ScheduleAttendanceDto>> GetScheduleForStudentWithAttendancesByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId);
        Task<IEnumerable<Attendance>> GetAttendancesForClassSubjectByPeriod(DateTime startDateTime, DateTime endDateTime, int classSubjectId);
        Task<int> UpdateAttendance(InsertAttendanceDto attendance);
    }
}