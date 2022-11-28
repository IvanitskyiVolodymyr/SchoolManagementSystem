using Dapper;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;   

namespace Infrastructure.Data.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;
        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionName = "SchoolManagementSystem")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionName));

            return await dbConnection.QueryAsync<T>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionName = "SchoolManagementSystem")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionName));

            return await dbConnection.ExecuteScalarAsync<int>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);

        }

        public async Task ExecuteSqlQueryAsync(string sqlQuery, string connectionName = "SchoolManagementSystem")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionName));
           
            await connection.ExecuteAsync(sqlQuery);
        }

        public async Task InsertRange<T>(IList<T> range, string sqlHeader, Func<T, string> selector, string connectionName = "SchoolManagementSystem")
        {
            var sqls = GetSqlsInBatches(range, sqlHeader, selector);

            using var connection = new SqlConnection(_configuration.GetConnectionString(connectionName));
            await connection.OpenAsync();
            var transaction = connection.BeginTransaction();
            try
            {
                foreach (var sqlQuery in sqls)
                {
                    await connection.ExecuteAsync(sqlQuery, new { }, transaction, commandType: CommandType.Text);
                }

                await transaction.CommitAsync();
            }
            catch(Exception e)
            {
                try
                {
                    await transaction.RollbackAsync();
                }
                catch(Exception inner)
                {
                    throw new Exception("Sql Rollback exception. " + inner.Message);
                }

                throw new Exception(e.Message);
            }
        }
        private IList<string> GetSqlsInBatches<T>(IList<T> range, string sqlHeader, Func<T,string> selector)
        {
            const int maxCountOfInsertPerRequest = 10;

            var sqlsToExecute = new List<string>();
            var numberOfBatches = (int)Math.Ceiling((double)range.Count / maxCountOfInsertPerRequest);

            for (int i = 0; i < numberOfBatches; i++)
            {
                var currentScheduleRange = range.Skip(i * maxCountOfInsertPerRequest).Take(maxCountOfInsertPerRequest);
                var valuesToInsert = currentScheduleRange.Select(selector);
                sqlsToExecute.Add(sqlHeader + string.Join(',', valuesToInsert));
            }

            return sqlsToExecute;
        }

        public string GetConnectionString(string connectionName = "SchoolManagementSystem")
        {
            return _configuration.GetConnectionString(connectionName);
        }
    }
}
