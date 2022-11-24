namespace Infrastructure.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionName = "SchoolManagementSystem");
        Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionName = "SchoolManagementSystem");
        Task ExecuteSqlQueryAsync(string sqlQuery, string connectionName = "SchoolManagementSystem");
        Task InsertScheduleRange<T>(IList<T> scheduleRange, string sqlHeader, Func<T, string> selector, string connectionName = "SchoolManagementSystem");
    }
}