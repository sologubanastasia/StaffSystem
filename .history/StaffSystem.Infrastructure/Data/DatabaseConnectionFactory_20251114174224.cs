namespace StaffSystem.Infrastructure.Data;
using System.Data;
using Npgsql;

public class DatabaseConnectionFactory
{
    private readonly string _connection;

    public DatabaseConnectionFactory(string connection)
    {
        _connection = connection;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connection);
    }
}