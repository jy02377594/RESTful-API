using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LXP.api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    HiredDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    TaskList = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StartTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    DeadLine = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskName);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "HiredDate", "LastName", "TaskList" },
                values: new object[] { new Guid("a3a461ea-e692-6f54-2f3e-f076a08dda14"), "XiaoPeng", new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), "Luo", "Fix bugs, CRUD a entity, Design module" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "HiredDate", "LastName", "TaskList" },
                values: new object[] { new Guid("16781dae-0522-a9d3-ac94-66d6b76aa772"), "GuanXi", new DateTimeOffset(new DateTime(2020, 11, 14, 18, 1, 15, 556, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, -6, 0, 0, 0)), "Chen", "Design module, Take Photo" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskName", "DeadLine", "EmployeeId", "StartTime" },
                values: new object[] { "Fix bugs", new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2020, 11, 14, 18, 1, 15, 557, DateTimeKind.Unspecified).AddTicks(4491), new TimeSpan(0, -6, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskName", "DeadLine", "EmployeeId", "StartTime" },
                values: new object[] { "CRUS a entity", new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2020, 11, 14, 18, 1, 15, 557, DateTimeKind.Unspecified).AddTicks(5648), new TimeSpan(0, -6, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskName", "DeadLine", "EmployeeId", "StartTime" },
                values: new object[] { "Design module", new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2020, 11, 14, 18, 1, 15, 557, DateTimeKind.Unspecified).AddTicks(5727), new TimeSpan(0, -6, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskName", "DeadLine", "EmployeeId", "StartTime" },
                values: new object[] { "Take photo", new DateTimeOffset(new DateTime(2028, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)), null, new DateTimeOffset(new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -6, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
