using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudentAPI.Application.Common.Interfaces;

namespace StudentAPI.Infrastructure.Persistence;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("ConnectionString 'DefaultConnection' is missing.");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}