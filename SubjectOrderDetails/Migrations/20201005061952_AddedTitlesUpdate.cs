using Microsoft.EntityFrameworkCore.Migrations;

namespace SubjectOrderDetails.Migrations
{
    public partial class AddedTitlesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "titleId",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "subjectId",
                keyValue: 1,
                column: "titleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "subjectId",
                keyValue: 2,
                column: "titleId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "subjectId",
                keyValue: 3,
                column: "titleId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_titleId",
                table: "Subjects",
                column: "titleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Titles_titleId",
                table: "Subjects",
                column: "titleId",
                principalTable: "Titles",
                principalColumn: "titleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Titles_titleId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_titleId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "titleId",
                table: "Subjects");
        }
    }
}
