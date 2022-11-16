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
    }
}
