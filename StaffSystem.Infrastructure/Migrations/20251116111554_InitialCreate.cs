using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "public",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                schema: "public",
                columns: table => new
                {
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "public",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "public",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "public",
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "public",
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionId",
                        column: x => x.PositionId,
                        principalSchema: "public",
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Company",
                columns: new[] { "CompanyId", "CompanyName" },
                values: new object[] { new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), "Головний офіс" });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Position",
                columns: new[] { "PositionId", "PositionName" },
                values: new object[,]
                {
                    { new Guid("11111111-2222-3333-4444-555555555511"), "Провідний розробник" },
                    { new Guid("22222222-2222-3333-4444-555555555522"), "Маркетолог" },
                    { new Guid("33333333-2222-3333-4444-555555555533"), "Фінансовий аналітик" },
                    { new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), "Секретар" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Department",
                columns: new[] { "DepartmentId", "CompanyId", "DepartmentName" },
                values: new object[,]
                {
                    { new Guid("c1f4e6d8-a3d2-c1f4-e6d8-a3d2c1f4e6d8"), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), "Відділ IT" },
                    { new Guid("d1d2d3d4-e5f6-7890-1234-567890a5b6c7"), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), "Відділ Маркетингу" },
                    { new Guid("f1f2f3f4-e5f6-7890-1234-567890a8b9c0"), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), "Фінансовий відділ" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "Employee",
                columns: new[] { "EmployeeId", "Address", "BirthDate", "CompanyId", "DepartmentId", "FirstName", "HireDate", "LastName", "MiddleName", "Phone", "PositionId", "Salary" },
                values: new object[,]
                {
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432101"), "Київ, вул. Хрещатик, 15", new DateTime(1995, 10, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("c1f4e6d8-a3d2-c1f4-e6d8-a3d2c1f4e6d8"), "Артем", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Боціон", "Миколайович", "097-111-22-33", new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), 30000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432102"), "Київ, бульв. Лесі Українки, 26", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("c1f4e6d8-a3d2-c1f4-e6d8-a3d2c1f4e6d8"), "Іван", new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Артеменко", "Петрович", "050-123-45-67", new Guid("11111111-2222-3333-4444-555555555511"), 65000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432103"), "Київ, вул. Сагайдачного, 10", new DateTime(1988, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("d1d2d3d4-e5f6-7890-1234-567890a5b6c7"), "Олена", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Михайлюк", "Сергіївна", "067-987-65-43", new Guid("22222222-2222-3333-4444-555555555522"), 45000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432104"), "Київ, просп. Перемоги, 33", new DateTime(1985, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("f1f2f3f4-e5f6-7890-1234-567890a8b9c0"), "Андрій", new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Семенюк", "Олександрович", "093-222-33-44", new Guid("33333333-2222-3333-4444-555555555533"), 55000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432105"), "Київ, вул. Ярославів Вал, 12", new DateTime(1998, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("c1f4e6d8-a3d2-c1f4-e6d8-a3d2c1f4e6d8"), "Юлія", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Коваленко", "Вікторівна", "098-333-44-55", new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), 32000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432106"), "Київ, вул. Костьольна, 3", new DateTime(1992, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("d1d2d3d4-e5f6-7890-1234-567890a5b6c7"), "Тарас", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Шевченко", "Григорович", "066-444-55-66", new Guid("22222222-2222-3333-4444-555555555522"), 48000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432107"), "Київ, вул. Антоновича, 70", new DateTime(1982, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("f1f2f3f4-e5f6-7890-1234-567890a8b9c0"), "Ірина", new DateTime(2020, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), "Бондаренко", "Олегівна", "096-555-66-77", new Guid("33333333-2222-3333-4444-555555555533"), 62000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432108"), "Київ, вул. Жилянська, 5", new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("c1f4e6d8-a3d2-c1f4-e6d8-a3d2c1f4e6d8"), "Дмитро", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Мельник", "Романович", "063-666-77-88", new Guid("11111111-2222-3333-4444-555555555511"), 70000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432109"), "Київ, Майдан Незалежності, 1", new DateTime(1996, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("d1d2d3d4-e5f6-7890-1234-567890a5b6c7"), "Катерина", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Грищенко", "Іванівна", "095-777-88-99", new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), 35000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432110"), "Київ, вул. Шовковична, 50", new DateTime(1987, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("f1f2f3f4-e5f6-7890-1234-567890a8b9c0"), "Володимир", new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Савчук", "Анатолійович", "099-888-99-00", new Guid("33333333-2222-3333-4444-555555555533"), 58000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432111"), "Київ, вул. Рейтарська, 14", new DateTime(1984, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("c1f4e6d8-a3d2-c1f4-e6d8-a3d2c1f4e6d8"), "Віталій", new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Пасічник", "Степанович", "097-999-00-11", new Guid("11111111-2222-3333-4444-555555555511"), 68000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432112"), "Київ, вул. Пушкінська, 22", new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("d1d2d3d4-e5f6-7890-1234-567890a5b6c7"), "Світлана", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Лисенко", "Василівна", "050-000-11-22", new Guid("22222222-2222-3333-4444-555555555522"), 42000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432113"), "Київ, вул. Володимирська, 56", new DateTime(1994, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("f1f2f3f4-e5f6-7890-1234-567890a8b9c0"), "Максим", new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ткаченко", "Ігорович", "067-111-22-33", new Guid("33333333-2222-3333-4444-555555555533"), 57000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432114"), "Київ, вул. Велика Васильківська, 44", new DateTime(1997, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("c1f4e6d8-a3d2-c1f4-e6d8-a3d2c1f4e6d8"), "Ольга", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Мороз", "Дмитрівна", "093-222-33-44", new Guid("a1b2c3d4-e5f6-7890-1234-567890abcdef"), 31000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432115"), "Київ, бульв. Тараса Шевченка, 11", new DateTime(1991, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("d1d2d3d4-e5f6-7890-1234-567890a5b6c7"), "Назар", new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Зінченко", "Богданович", "098-333-44-55", new Guid("22222222-2222-3333-4444-555555555522"), 50000.00m },
                    { new Guid("e9d8c7b6-a5f4-3e2d-1c0b-9a8765432116"), "Київ, вул. Богдана Хмельницького, 48", new DateTime(1989, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b0e7a2b0-9e1d-4f8e-9c0a-3d2c1f4e6d8a"), new Guid("c1f4e6d8-a3d2-c1f4-e6d8-a3d2c1f4e6d8"), "Марія", new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Поліщук", "Андріївна", "066-444-55-66", new Guid("11111111-2222-3333-4444-555555555511"), 63000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_CompanyId",
                schema: "public",
                table: "Department",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                schema: "public",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                schema: "public",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                schema: "public",
                table: "Employee",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Position",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Company",
                schema: "public");
        }
    }
}
