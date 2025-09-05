using Microsoft.Data.SqlClient;

namespace I_AM.Infrastructure.Persistence.Contracts;

public interface IExecuteQuery
{
    Task<string> GetQuery(string storedProcedure, List<SqlParameter> parameters);
}