using Npgsql;

namespace I_AM.Infrastructure.Persistence.Contracts;

public interface IExecuteQuery
{
    Task<string> GetQuery(string storedProcedure, List<NpgsqlParameter> parameters);
}