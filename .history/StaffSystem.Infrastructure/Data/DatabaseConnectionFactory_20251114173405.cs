namespace StaffSystem.Infrastructure.Data;
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