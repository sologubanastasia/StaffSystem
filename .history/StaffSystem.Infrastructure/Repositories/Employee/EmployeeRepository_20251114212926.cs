namespace StaffSystem.Infrastructure.Repositories;

using System.Collections.Generic;
using StaffSystem.Infrastructure.Data;
using StaffSystem.Domain.Entities;
using Npgsql;
using StaffSystem.Application.Interfaces; // Додано IEmployeeRepository (інтерфейс, який ви, ймовірно, використовуєте)

// Примітка: Припускається, що DatabaseConnectionFactory є PostgresConnectionFactory
public class EmployeeRepository : IEmployeeRepository
{
    private readonly DatabaseConnectionFactory _factory;

    public EmployeeRepository(DatabaseConnectionFactory factory)
    {
        _factory = factory;
    }

    private Employee MapReaderToEmployee(NpgsqlDataReader reader)
    {
        return new Employee
        {
            EmployeeId = reader.GetGuid(reader.GetOrdinal("EmployeeId")),
            // MiddleName має бути наявний у DTO та таблиці, щоб тут працювати
            FirstName = reader["FirstName"] as string ?? "",
            LastName = reader["LastName"] as string ?? "",
            MiddleName = reader["MiddleName"] as string ?? "",
            Address = reader["Address"] as string ?? "",
            Phone = reader["Phone"] as string ?? "",
            BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
            HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate")),
            Salary = reader.GetDecimal(reader.GetOrdinal("Salary")),

            Department = new Department
            {
                DepartmentId = reader.GetGuid(reader.GetOrdinal("DepartmentId")),
                DepartmentName = reader["DepartmentName"] as string ?? ""
            },

            Position = new Position
            {
                PositionId = reader.GetGuid(reader.GetOrdinal("PositionId")),
                PositionName = reader["PositionName"] as string ?? ""
            },

            Company = new Company
            {
                CompanyId = reader.GetGuid(reader.GetOrdinal("CompanyId")),
                CompanyName = reader["CompanyName"] as string ?? "" 
            }
        };
    }

    public IEnumerable<Employee> GetAll(string? department, string? position, string? name)
    {
        var list = new List<Employee>();

        using var connection = (NpgsqlConnection)_factory.CreateConnection();
        connection.Open();

        var sql = @"
            SELECT 
                e.*, 
                d.""DepartmentName"", 
                p.""PositionName"", 
                c.""CompanyName"" AS ""CompanyName""  -- ✅ ВИПРАВЛЕНО: Змінено c.""Name"" на c.""CompanyName""
            FROM 
                ""Employee"" e
            JOIN 
                ""Department"" d ON e.""DepartmentId"" = d.""DepartmentId""
            JOIN 
                ""Position"" p ON e.""PositionId"" = p.""PositionId""
            JOIN 
                ""Company"" c ON e.""CompanyId"" = c.""CompanyId""
            WHERE (@department IS NULL OR d.""DepartmentName"" ILIKE '%' || @department || '%')
              AND (@position IS NULL OR p.""PositionName"" ILIKE '%' || @position || '%')
              AND (@name IS NULL OR (e.""LastName"" || ' ' || e.""FirstName"" || ' ' || COALESCE(e.""MiddleName"", '')) ILIKE '%' || @name || '%') -- Додано MiddleName до фільтрації
            ORDER BY e.""LastName"", e.""FirstName"";";

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("@department", (object?)department ?? DBNull.Value);
        command.Parameters.AddWithValue("@position", (object?)position ?? DBNull.Value);
        command.Parameters.AddWithValue("@name", (object?)name ?? DBNull.Value);

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            list.Add(MapReaderToEmployee(reader));
        }
        return list;
    }

    public Employee? GetById(Guid id)
    {
        using var connection = (NpgsqlConnection)_factory.CreateConnection();
        connection.Open();

        var sql = @"
            SELECT 
                e.*, 
                d.""DepartmentName"", 
                p.""PositionName"", 
                c.""CompanyName"" AS ""CompanyName"" -- ✅ ВИПРАВЛЕНО: Змінено c.""Name"" на c.""CompanyName""
            FROM 
                ""Employee"" e
            JOIN 
                ""Department"" d ON e.""DepartmentId"" = d.""DepartmentId""
            JOIN 
                ""Position"" p ON e.""PositionId"" = p.""PositionId""
            JOIN 
                ""Company"" c ON e.""CompanyId"" = c.""CompanyId""
            WHERE e.""EmployeeId"" = @id;";

        using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return MapReaderToEmployee(reader);
        }

        return null;
    }

    public void Update(Employee employee)
    {
        using var connection = (NpgsqlConnection)_factory.CreateConnection();
        connection.Open();

        var sql = @"
            UPDATE ""Employee""
            SET 
                ""FirstName""=@fn, 
                ""LastName""=@ln, 
                ""MiddleName""=@mn, 
                ""Address""=@addr, 
                ""Phone""=@phone, 
                ""BirthDate""=@bd, 
                ""HireDate""=@hd, 
                ""Salary""=@sal,
                ""DepartmentId""=@did, 
                ""PositionId""=@pid, 
                ""CompanyId""=@cid
            WHERE ""EmployeeId""=@id";

        using var command = new NpgsqlCommand(sql, connection);

        command.Parameters.AddWithValue("@id", employee.EmployeeId);
        command.Parameters.AddWithValue("@fn", (object?)employee.FirstName ?? DBNull.Value);
        command.Parameters.AddWithValue("@ln", (object?)employee.LastName ?? DBNull.Value);
        command.Parameters.AddWithValue("@mn", (object?)employee.MiddleName ?? DBNull.Value);
        command.Parameters.AddWithValue("@addr", (object?)employee.Address ?? DBNull.Value);
        command.Parameters.AddWithValue("@phone", (object?)employee.Phone ?? DBNull.Value);
        command.Parameters.AddWithValue("@bd", employee.BirthDate);
        command.Parameters.AddWithValue("@hd", employee.HireDate);
        command.Parameters.AddWithValue("@sal", employee.Salary);
        command.Parameters.AddWithValue("@did", employee.Department.DepartmentId);
        command.Parameters.AddWithValue("@pid", employee.Position.PositionId);
        command.Parameters.AddWithValue("@cid", employee.Company.CompanyId);

        command.ExecuteNonQuery();
    }
}