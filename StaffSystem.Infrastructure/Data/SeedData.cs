using StaffSystem.Domain.Entities;
using System.Collections.Generic;

namespace StaffSystem.Infrastructure
{
    public static class SeedData
    {
        public static readonly Company DefaultCompany = new Company
        {
            CompanyId = new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"),
            CompanyName = "Головний офіс"
        };

        public static readonly List<Department> Departments = new List<Department>
        {
            new Department {
                DepartmentId = new Guid("c1f4e6d8-a3d2-c1f4-e6d8-a3d2c1f4e6d8"),
                CompanyId = DefaultCompany.CompanyId,
                DepartmentName = "Відділ IT"
            },
            new Department {
                DepartmentId = new Guid("d1d2d3d4-e5f6-7890-1234-567890a5b6c7"),
                CompanyId = DefaultCompany.CompanyId,
                DepartmentName = "Відділ Маркетингу"
            },
            new Department {
                DepartmentId = new Guid("f1f2f3f4-e5f6-7890-1234-567890a8b9c0"),
                CompanyId = DefaultCompany.CompanyId,
                DepartmentName = "Фінансовий відділ"
            }
        };

        public static readonly Guid PositionSecretaryId = new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef");
        public static readonly Guid PositionDeveloperId = new Guid("11111111-2222-3333-4444-555555555511");
        public static readonly Guid PositionMarketerId = new Guid("22222222-2222-3333-4444-555555555522");
        public static readonly Guid PositionAnalystId = new Guid("33333333-2222-3333-4444-555555555533");
        
        public static readonly List<Position> Positions = new List<Position>
        {
            new Position { PositionId = PositionSecretaryId, PositionName = "Секретар" },
            new Position { PositionId = PositionDeveloperId, PositionName = "Провідний розробник" },
            new Position { PositionId = PositionMarketerId, PositionName = "Маркетолог" },
            new Position { PositionId = PositionAnalystId, PositionName = "Фінансовий аналітик" }
        };

        public static readonly List<Employee> Employees = new List<Employee>
        {
            new Employee 
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432101"),
                FirstName = "Артем", MiddleName = "Миколайович", LastName = "Боціон",
                Address = "Київ, вул. Хрещатик, 15", Phone = "097-111-22-33", 
                BirthDate = new DateTime(1995, 10, 20, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2023, 03, 01, 0, 0, 0, DateTimeKind.Utc),
                Salary = 30000.00m,
                DepartmentId = Departments[0].DepartmentId,
                PositionId = PositionSecretaryId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432102"),
                FirstName = "Іван", MiddleName = "Петрович", LastName = "Артеменко",
                Address = "Київ, бульв. Лесі Українки, 26", Phone = "050-123-45-67",
                BirthDate = new DateTime(1990, 05, 15, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2022, 05, 15, 0, 0, 0, DateTimeKind.Utc),
                Salary = 65000.00m,
                DepartmentId = Departments[0].DepartmentId, 
                PositionId = PositionDeveloperId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432103"),
                FirstName = "Олена", MiddleName = "Сергіївна", LastName = "Михайлюк",
                Address = "Київ, вул. Сагайдачного, 10", Phone = "067-987-65-43",
                BirthDate = new DateTime(1988, 11, 20, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2023, 11, 20, 0, 0, 0, DateTimeKind.Utc),
                Salary = 45000.00m,
                DepartmentId = Departments[1].DepartmentId, 
                PositionId = PositionMarketerId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432104"),
                FirstName = "Андрій", MiddleName = "Олександрович", LastName = "Семенюк",
                Address = "Київ, просп. Перемоги, 33", Phone = "093-222-33-44",
                BirthDate = new DateTime(1985, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2021, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                Salary = 55000.00m,
                DepartmentId = Departments[2].DepartmentId, 
                PositionId = PositionAnalystId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432105"),
                FirstName = "Юлія", MiddleName = "Вікторівна", LastName = "Коваленко",
                Address = "Київ, вул. Ярославів Вал, 12", Phone = "098-333-44-55",
                BirthDate = new DateTime(1998, 01, 10, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2024, 01, 10, 0, 0, 0, DateTimeKind.Utc),
                Salary = 32000.00m,
                DepartmentId = Departments[0].DepartmentId, 
                PositionId = PositionSecretaryId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432106"),
                FirstName = "Тарас", MiddleName = "Григорович", LastName = "Шевченко",
                Address = "Київ, вул. Костьольна, 3", Phone = "066-444-55-66",
                BirthDate = new DateTime(1992, 09, 01, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2022, 09, 01, 0, 0, 0, DateTimeKind.Utc),
                Salary = 48000.00m,
                DepartmentId = Departments[1].DepartmentId, 
                PositionId = PositionMarketerId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432107"),
                FirstName = "Ірина", MiddleName = "Олегівна", LastName = "Бондаренко",
                Address = "Київ, вул. Антоновича, 70", Phone = "096-555-66-77",
                BirthDate = new DateTime(1982, 04, 25, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2020, 04, 25, 0, 0, 0, DateTimeKind.Utc),
                Salary = 62000.00m,
                DepartmentId = Departments[2].DepartmentId, 
                PositionId = PositionAnalystId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432108"),
                FirstName = "Дмитро", MiddleName = "Романович", LastName = "Мельник",
                Address = "Київ, вул. Жилянська, 5", Phone = "063-666-77-88",
                BirthDate = new DateTime(1993, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2021, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                Salary = 70000.00m,
                DepartmentId = Departments[0].DepartmentId, 
                PositionId = PositionDeveloperId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432109"),
                FirstName = "Катерина", MiddleName = "Іванівна", LastName = "Грищенко",
                Address = "Київ, Майдан Незалежності, 1", Phone = "095-777-88-99",
                BirthDate = new DateTime(1996, 06, 15, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2023, 06, 15, 0, 0, 0, DateTimeKind.Utc),
                Salary = 35000.00m,
                DepartmentId = Departments[1].DepartmentId, 
                PositionId = PositionSecretaryId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432110"),
                FirstName = "Володимир", MiddleName = "Анатолійович", LastName = "Савчук",
                Address = "Київ, вул. Шовковична, 50", Phone = "099-888-99-00",
                BirthDate = new DateTime(1987, 02, 10, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2022, 02, 10, 0, 0, 0, DateTimeKind.Utc),
                Salary = 58000.00m,
                DepartmentId = Departments[2].DepartmentId, 
                PositionId = PositionAnalystId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432111"),
                FirstName = "Віталій", MiddleName = "Степанович", LastName = "Пасічник",
                Address = "Київ, вул. Рейтарська, 14", Phone = "097-999-00-11",
                BirthDate = new DateTime(1984, 12, 05, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2020, 12, 05, 0, 0, 0, DateTimeKind.Utc),
                Salary = 68000.00m,
                DepartmentId = Departments[0].DepartmentId, 
                PositionId = PositionDeveloperId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432112"),
                FirstName = "Світлана", MiddleName = "Василівна", LastName = "Лисенко",
                Address = "Київ, вул. Пушкінська, 22", Phone = "050-000-11-22",
                BirthDate = new DateTime(1999, 03, 01, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2024, 03, 01, 0, 0, 0, DateTimeKind.Utc),
                Salary = 42000.00m,
                DepartmentId = Departments[1].DepartmentId, 
                PositionId = PositionMarketerId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432113"),
                FirstName = "Максим", MiddleName = "Ігорович", LastName = "Ткаченко",
                Address = "Київ, вул. Володимирська, 56", Phone = "067-111-22-33",
                BirthDate = new DateTime(1994, 07, 01, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2023, 07, 01, 0, 0, 0, DateTimeKind.Utc),
                Salary = 57000.00m,
                DepartmentId = Departments[2].DepartmentId, 
                PositionId = PositionAnalystId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432114"),
                FirstName = "Ольга", MiddleName = "Дмитрівна", LastName = "Мороз",
                Address = "Київ, вул. Велика Васильківська, 44", Phone = "093-222-33-44",
                BirthDate = new DateTime(1997, 05, 01, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2024, 05, 01, 0, 0, 0, DateTimeKind.Utc),
                Salary = 31000.00m,
                DepartmentId = Departments[0].DepartmentId, 
                PositionId = PositionSecretaryId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432115"),
                FirstName = "Назар", MiddleName = "Богданович", LastName = "Зінченко",
                Address = "Київ, бульв. Тараса Шевченка, 11", Phone = "098-333-44-55",
                BirthDate = new DateTime(1991, 10, 10, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2021, 10, 10, 0, 0, 0, DateTimeKind.Utc),
                Salary = 50000.00m,
                DepartmentId = Departments[1].DepartmentId, 
                PositionId = PositionMarketerId,
                CompanyId = DefaultCompany.CompanyId
            },
            new Employee
            {
                EmployeeId = new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432116"),
                FirstName = "Марія", MiddleName = "Андріївна", LastName = "Поліщук",
                Address = "Київ, вул. Богдана Хмельницького, 48", Phone = "066-444-55-66",
                BirthDate = new DateTime(1989, 08, 08, 0, 0, 0, DateTimeKind.Utc),
                HireDate = new DateTime(2022, 08, 08, 0, 0, 0, DateTimeKind.Utc),
                Salary = 63000.00m,
                DepartmentId = Departments[0].DepartmentId, 
                PositionId = PositionDeveloperId,
                CompanyId = DefaultCompany.CompanyId
            }
        };
    }
}