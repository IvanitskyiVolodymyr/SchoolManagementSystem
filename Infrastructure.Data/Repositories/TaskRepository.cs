using Common.Dtos.StudentTask;
using Common.Dtos.Tasks;
using Common.Dtos.Users;
using Dapper;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;
using System.Data.SqlClient;

namespace Infrastructure.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ISqlDataAccess _dataHelper;

        public TaskRepository(ISqlDataAccess dataHelper)
        {
            _dataHelper = dataHelper;
        }

        public async Task<IEnumerable<ResponseTaskDto>> GetTasksByStudentId(int studentId, DateTime from, DateTime to)
        {
            return await _dataHelper.LoadData<ResponseTaskDto, dynamic>("spTask_GetByStudentId", new { StudentId = studentId, StartDateTime = from, EndDateTime = to});
        }

        public async Task<int> InsertStudentTask(InsertStudentTaskDto studentTaskDto)
        {
            return await _dataHelper.SaveData("spStudentTask_Insert", studentTaskDto);
        }

        public async Task<int> InsertTask(InsertTaskDto taskDto)
        {
            return await _dataHelper.SaveData("spTask_Insert", taskDto);
        }

        public async Task<int> InsertTaskForScheduleId(InsertTaskDto taskDto)
        {
            using var connection = new SqlConnection(_dataHelper.GetConnectionString());
            await connection.OpenAsync();
            var transaction = connection.BeginTransaction();
            try
            {
                int taskId = await connection.ExecuteScalarAsync<int>("spTask_Insert", taskDto, transaction, commandType: System.Data.CommandType.StoredProcedure);

                var students = await connection.QueryAsync<GetStudentDto>("spUser_GetAllByScheduleId",
                                                                          new { ScheduleId = taskDto.ScheduleId },
                                                                          transaction,
                                                                          commandType: System.Data.CommandType.StoredProcedure);

                foreach(var student in students)
                {
                    await connection.ExecuteScalarAsync("spStudentTask_Insert",
                                                        new InsertStudentTaskDto { StudentId = student.StudentId, TaskId = taskId },
                                                        transaction,
                                                        commandType: System.Data.CommandType.StoredProcedure);
                }

                await transaction.CommitAsync();
                return taskId;
            }
            catch(Exception e)
            {
                await transaction.RollbackAsync();
                throw new Exception("Sql transaction exception: " + e.Message);
            }
        }

        public async Task<int> UpdateStudentTask(UpdateStudentTaskDto studentTaskDto)
        {
            await _dataHelper.SaveData("spStudentTask_Update", studentTaskDto);
            return studentTaskDto.TaskId;
        }

        public async Task<int> UpdateTask(UpdateTaskDto task)
        {
            await _dataHelper.SaveData("spTask_Update", task);
            return task.TaskId;
        }
    }
}
