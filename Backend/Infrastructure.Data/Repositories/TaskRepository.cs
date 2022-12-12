using Common.Dtos.StudentTask;
using Common.Dtos.StudentTaskAttachment;
using Common.Dtos.Tasks;
using Common.Dtos.Users;
using Dapper;
using Domain.Core.Entities;
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

        public async Task<IEnumerable<ResponseTaskDto>> GetCheckedStudentTaskByStudentId(int studentId, DateTime from, DateTime to)
        {
            return await _dataHelper.LoadData<ResponseTaskDto, dynamic>("spTask_GetCheckedByStudentId", new { StudentId = studentId, From = from, To = to });
        }

        public async Task<IEnumerable<StudentTaskAttachmentDto>> GetStudentTaskAttachments(int studentTaskId)
        {
            return await _dataHelper.LoadData<StudentTaskAttachmentDto, dynamic>("spStudentTaskAttachment_GetByStudentTaskId", new { StudentTaskId = studentTaskId });
        }

        public async Task<StudentTask?> GetStudentTaskById(int studentTaskId)
        {
            var result = await _dataHelper.LoadData<StudentTask, dynamic>("spStudentTask_GetById", new { StudentTaskId = studentTaskId });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ResponseTaskDto>> GetAllUncheckedTasksForStudent(int studentId)
        {
            return await _dataHelper.LoadData<ResponseTaskDto, dynamic>("spTask_GetUncheckedByStudentId", new { StudentId = studentId });
        }

        public async Task<IEnumerable<ResponseTeacherTaskDto>> GetUncheckedTasksByTeacherIdSubjectIdClassId(int teacherId, int subjectId, int classId)
        {
            return await _dataHelper.LoadData<ResponseTeacherTaskDto, dynamic>("spTask_GetByTeacherIdSubjectIdClassId",
                                                                               new { TeacherId = teacherId, SubjectId = subjectId, ClassId = classId, IsDone = true, IsChecked = false });
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

        public async Task<int> UpdateStudentTaskWithAttachments(UpdateStudentTaskDto studentTaskDto, List<InsertStudentTaskAttachmentDto> attachments)
        {
            using var connection = new SqlConnection(_dataHelper.GetConnectionString());
            await connection.OpenAsync();
            var transaction = connection.BeginTransaction();

            try
            {
                foreach(var attachment in attachments)
                {
                    await connection.ExecuteScalarAsync("spStudentTaskAttachment_Insert",
                                                        new InsertStudentTaskAttachmentDto { StudentTaskId = attachment.StudentTaskId, FileUrl = attachment.FileUrl },
                                                        transaction,
                                                        commandType: System.Data.CommandType.StoredProcedure);
                }

                await connection.ExecuteScalarAsync<int>("spStudentTask_Update", studentTaskDto, transaction, commandType: System.Data.CommandType.StoredProcedure);

                await transaction.CommitAsync();
                return studentTaskDto.TaskId;
            }
            catch(Exception e)
            {
                await transaction.RollbackAsync();
                throw new Exception("SQL transaction exception " + e.Message);
            }
        }

        public async Task<int> UpdateTask(UpdateTaskDto task)
        {
            await _dataHelper.SaveData("spTask_Update", task);
            return task.TaskId;
        }

        public async Task<IEnumerable<ResponseTaskDto>> GetAllHomeworksForStudent(int studentId, DateTime from, DateTime to)
        {
            return await _dataHelper.LoadData<ResponseTaskDto, dynamic>("spTask_GetAllByPeriodAndType", new { StudentId = studentId, From = from, To = to, TaskType = TaskType.HomeWork });
        }
    }
}
