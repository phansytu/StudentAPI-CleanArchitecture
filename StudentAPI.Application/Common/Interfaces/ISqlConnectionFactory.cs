using System.Data;

namespace StudentAPI.Application.Common.Interfaces;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}