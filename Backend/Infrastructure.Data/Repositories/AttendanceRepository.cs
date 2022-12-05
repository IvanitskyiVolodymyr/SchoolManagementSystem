using Common.Dtos.Attendance;
using Common.Dtos.Schedule;
using Dapper;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Infrastructure.Data.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ISqlDataAccess _dataHelper;

        public AttendanceRepository(ISqlDataAccess db)
        {
            _dataHelper = db;
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesForClassSubjectByPeriod(DateTime startDateTime, DateTime endDateTime, int classSubjectId)
        {
            return await _dataHelper.LoadData<Attendance, dynamic>("spAttendance_GetForClassSubjectByPeriod", new
            {
                ClassSubjectId = classSubjectId,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            });
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesForStudentByPeriod(DateTime startDateTime, DateTime endDateTime, int studentId)
        {
            return await _dataHelper.LoadData<Attendance, dynamic>("spAttendance_GetForStudentByPeriod", new
            {
                StudentId = studentId,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime
            });
        }

        public async Task<List<int>> InsertAttendances(IList<InsertAttendanceDto> attendances, int scheduleId)
        {
            using var connection = new SqlConnection(_dataHelper.GetConnectionString());
            await connection.OpenAsync();
            var transaction = connection.BeginTransaction();
            List<int> outputIds = new List<int>();
            try
            {
                foreach (var attendance in attendances)
                {
                    outputIds.Add(await connection.ExecuteAsync("spAttendance_Insert",
                                                                new { ScheduleId = scheduleId, StudentId = attendance.StudentId, Status = attendance.Status },
                                                                transaction,
                                                                commandType: System.Data.CommandType.StoredProcedure));
                }
                await connection.ExecuteAsync("spSchedule_UpdateAttendanceCheck",
                                              new { ScheduleId = scheduleId, IsAttendanceChecked = true },
                                              transaction,
                                              commandType: System.Data.CommandType.StoredProcedure);

                await transaction.CommitAsync();
            }
            catch(Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
            return outputIds;
        }

        public async Task<int> UpdateAttendance(UpdateAttendanceDto attendance)
        {
            await _dataHelper.SaveData("spAttendance_Update", attendance);
            return 1;
        }
    }
}
