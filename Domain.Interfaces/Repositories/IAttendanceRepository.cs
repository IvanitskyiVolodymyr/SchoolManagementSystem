using Common.Dtos.Attendance;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAttendanceRepository
    {
        Task<List<int>> InsertAttendances(IList<InsertAttendanceDto> attendances, int scheduleId);
        Task<IEnumerable<Attendance>> GetAttendancesForStudentByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId);
        Task<IEnumerable<Attendance>> GetAttendancesForClassSubjectByPeriod(DateTime startDateTime, DateTime endDateTime, int classSubjectId);
        Task<int> UpdateAttendance(InsertAttendanceDto attendance);
    }
}
