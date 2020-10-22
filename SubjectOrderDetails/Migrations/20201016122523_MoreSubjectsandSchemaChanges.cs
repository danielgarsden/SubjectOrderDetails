using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubjectOrderDetails.Migrations
{
    public partial class MoreSubjectsandSchemaChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Titles_titleId",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "titleId",
                table: "Subjects",
                newName: "TitleId");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Subjects",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Subjects",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "dateOfBirth",
                table: "Subjects",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "subjectId",
                table: "Subjects",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_titleId",
                table: "Subjects",
                newName: "IX_Subjects_TitleId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Subjects",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "DateOfBirth", "FirstName", "LastName", "TitleId" },
                values: new object[] { 4, new DateTimeOffset(new DateTime(1949, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Phillip", "Garsden", 4 });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectId", "DateOfBirth", "FirstName", "LastName", "TitleId" },
                values: new object[] { 5, new DateTimeOffset(new DateTime(1986, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Jennifer", "Garsden", 4 });

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Titles_TitleId",
                table: "Subjects",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "titleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Titles_TitleId",
                table: "Subjects");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectId",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "TitleId",
                table: "Subjects",
                newName: "titleId");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Subjects",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Subjects",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Subjects",
                newName: "dateOfBirth");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Subjects",
                newName: "subjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_TitleId",
                table: "Subjects",
                newName: "IX_Subjects_titleId");

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Subjects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Titles_titleId",
                table: "Subjects",
                column: "titleId",
                principalTable: "Titles",
                principalColumn: "titleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
