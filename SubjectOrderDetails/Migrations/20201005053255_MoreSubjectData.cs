using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubjectOrderDetails.Migrations
{
#pragma warning disable CS1591

    public partial class MoreSubjectData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "subjectId", "dateOfBirth", "firstName", "lastName" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2015, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tamas", "Garsden" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "subjectId", "dateOfBirth", "firstName", "lastName" },
                values: new object[] { 3, new DateTimeOffset(new DateTime(2017, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Alma", "Garsden" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "subjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "subjectId",
                keyValue: 3);
        }
    }

#pragma warning restore CS1591
}
