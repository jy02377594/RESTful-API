using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LXP.api.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskList",
                table: "Employees",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("16781dae-0522-a9d3-ac94-66d6b76aa772"),
                columns: new[] { "HiredDate", "TaskList" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 11, 16, 12, 21, 32, 91, DateTimeKind.Unspecified).AddTicks(7878), new TimeSpan(0, -6, 0, 0, 0)), "Design module, Take photo" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskName",
                keyValue: "CRUS a entity",
                column: "StartTime",
                value: new DateTimeOffset(new DateTime(2020, 11, 16, 12, 21, 32, 93, DateTimeKind.Unspecified).AddTicks(2206), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskName",
                keyValue: "Design module",
                column: "StartTime",
                value: new DateTimeOffset(new DateTime(2020, 11, 16, 12, 21, 32, 93, DateTimeKind.Unspecified).AddTicks(2280), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskName",
                keyValue: "Fix bugs",
                column: "StartTime",
                value: new DateTimeOffset(new DateTime(2020, 11, 16, 12, 21, 32, 93, DateTimeKind.Unspecified).AddTicks(744), new TimeSpan(0, -6, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskList",
                table: "Employees",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("16781dae-0522-a9d3-ac94-66d6b76aa772"),
                columns: new[] { "HiredDate", "TaskList" },
                values: new object[] { new DateTimeOffset(new DateTime(2020, 11, 14, 18, 1, 15, 556, DateTimeKind.Unspecified).AddTicks(2339), new TimeSpan(0, -6, 0, 0, 0)), "Design module, Take Photo" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskName",
                keyValue: "CRUS a entity",
                column: "StartTime",
                value: new DateTimeOffset(new DateTime(2020, 11, 14, 18, 1, 15, 557, DateTimeKind.Unspecified).AddTicks(5648), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskName",
                keyValue: "Design module",
                column: "StartTime",
                value: new DateTimeOffset(new DateTime(2020, 11, 14, 18, 1, 15, 557, DateTimeKind.Unspecified).AddTicks(5727), new TimeSpan(0, -6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskName",
                keyValue: "Fix bugs",
                column: "StartTime",
                value: new DateTimeOffset(new DateTime(2020, 11, 14, 18, 1, 15, 557, DateTimeKind.Unspecified).AddTicks(4491), new TimeSpan(0, -6, 0, 0, 0)));
        }
    }
}
