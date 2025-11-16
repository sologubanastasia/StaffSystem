namespace StaffSystem.Infrastructure.Data;
using System.Data;
using System.Data.SqlClient;

public class DatabaseConnectionFactory
{
    private readonly string _connection;

    public SqlConnectionFactory(string connection)
    {
        _connection = connection;
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connection);
    }
}