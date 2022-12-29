using Common.Dtos.StudentTaskComment;
using Common.Dtos.Users;
using Dapper;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;
using System.Data.SqlClient;

namespace Infrastructure.Data.Repositories
{
    public class StudentTaskCommentRepository : IStudentTaskCommentRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        public StudentTaskCommentRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<int> CreateComment(CreateStudentTaskCommentDto comment)
        {
            return await _dataAccess.SaveData("spStudentTaskComment_Create", comment);
        }

        public async Task<IEnumerable<ResponseStudentTaskCommentDto>> GetCommentsByStudentTaskId(int studentTaskId)
        {
            using var connection = new SqlConnection(_dataAccess.GetConnectionString());

            var result = await connection.QueryAsync<ResponseStudentTaskCommentDto, ShortUserInfoDto, ResponseStudentTaskCommentDto>(
                "spStudentTaskComment_GetByStudentTaskId",
                (rst, u) =>
                {
                    rst.ShortUserInfo = u;
                    return rst;
                },
                new { StudentTaskId = studentTaskId },
                splitOn:"UserId",
                commandType: System.Data.CommandType.StoredProcedure
                );

            return result;
        }

        public async Task<ResponseStudentTaskCommentDto?> GetCommentsByStudentTaskCommentId(int studentTaskCommentId)
        {
            using var connection = new SqlConnection(_dataAccess.GetConnectionString());

            var result = await connection.QueryAsync<ResponseStudentTaskCommentDto, ShortUserInfoDto, ResponseStudentTaskCommentDto>(
                "spStudenTaskComment_getByStudentTaskCommentId",
                (rst, u) =>
                {
                    rst.ShortUserInfo = u;
                    return rst;
                },
                new { StudentTaskCommentId = studentTaskCommentId },
                splitOn: "UserId",
                commandType: System.Data.CommandType.StoredProcedure
                );

            return result.FirstOrDefault();
        }

        public async Task<int> UpdateComment(UpdateStudentTaskCommentDto comment)
        {
            await _dataAccess.SaveData("spStudentTaskComment_Update", comment);
            return comment.StudentTaskCommentId;
        }
    }
}
