namespace Infrastructure.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionName = "SchoolManagementSystem");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionName = "SchoolManagementSystem");
    }
}