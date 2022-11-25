using Common.Dtos.Schedule;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ISqlDataAccess _db;

        public ScheduleRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Schedule>> GetScheduleForStudentByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId)
        {
            return await _db.LoadData<Schedule, dynamic>("spSchedule_GetForStudentByPeriod", new
            {
                StartDateTime = startDateTime,
                EndDateTime = endDateTime,
                StudentId = studentId
            });
        }

        public async Task<IEnumerable<Schedule>> GetScheduleForTeacherByPeriod(DateTime startDateTime, DateTime endDateTime, int teacherId)
        {
            return await _db.LoadData<Schedule, dynamic>("spSchedule_GetForTeacherByPeriod", new
            {
                StartDateTime = startDateTime,
                EndDateTime = endDateTime,
                TeacherId = teacherId
            });
        }

        public async Task<int> InsertSchedule(InsertScheduleDto scheduleDto)
        {
            return await _db.SaveData("spSchedule_Insert", scheduleDto);
        }

        public async Task InsertScheduleRange(IList<InsertScheduleDto> scheduleRange)
        {
            var sqlHeader = "INSERT INTO [school].[Schedules] (StartTime, ClassSubjectId, EndTime, Place) VALUES ";
            var sqlValues = "('{0}', {1}, '{2}', '{3}')";

            await _db.InsertRange<InsertScheduleDto>(scheduleRange, sqlHeader, (s) => string.Format(sqlValues, s.StartTime, s.ClassSubjectId, s.EndTime, s.Place));
        }

        public async Task<int> UpdateSchedule(Schedule schedule)
        {
            await _db.SaveData("spSchedule_Update", schedule);
            return schedule.ScheduleId;
        }
    }
}
