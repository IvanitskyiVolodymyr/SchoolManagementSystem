using Common.Dtos.Attendance;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAttendanceRepository
    {
        Task<int> InsertAttendances(IList<InsertAttendanceDto> attendances);
        Task<IEnumerable<Attendance>> GetAttendancesForStudentByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId);
        Task<IEnumerable<Attendance>> GetAttendancesForClassSubjectByPeriod(DateTime startDateTime, DateTime endDateTime, int classSubjectId);
        Task<int> UpdateAttendance(InsertAttendanceDto attendance);
    }
}
