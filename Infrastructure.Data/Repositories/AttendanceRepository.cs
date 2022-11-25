using Common.Dtos.Attendance;
using Common.Dtos.Schedule;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ISqlDataAccess _db;

        public AttendanceRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesForClassSubjectByPeriod(DateTime startDateTime, DateTime endDateTime, int classSubjectId)
        {
            return await _db.LoadData<Attendance, dynamic>("spAttendance_GetForClassSubjectByPeriod", new
            {
                ClassSubjectId = classSubjectId,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            });
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesForStudentByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId)
        {
            return await _db.LoadData<Attendance, dynamic>("spAttendance_GetForStudentByPeriod", new
            {
                StudentId = studentId,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            });
        }

        public async Task<int> InsertAttendances(IList<InsertAttendanceDto> attendances)
        {
            var sqlHeader = "INSERT INTO [school].[Attendances] (ScheduleId, StudentId, Status) VALUES ";
            var sqlValues = "({0}, {1}, {2})";

            await _db.InsertRange<InsertAttendanceDto>(attendances, sqlHeader, (a) => string.Format(sqlValues, a.ScheduleId, a.StudentId, (int)a.Status));
            return 1;
        }

        public async Task<int> UpdateAttendance(InsertAttendanceDto attendance)
        {
            await _db.SaveData("spAttendance_Update", attendance);
            return 1;
        }
    }
}
