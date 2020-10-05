using Microsoft.EntityFrameworkCore.Migrations;

namespace SubjectOrderDetails.Migrations
{
    public partial class AddedTitles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    titleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.titleId);
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "titleId", "titleName" },
                values: new object[,]
                {
                    { 1, "Mr" },
                    { 2, "Mrs" },
                    { 3, "Master" },
                    { 4, "Miss" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
