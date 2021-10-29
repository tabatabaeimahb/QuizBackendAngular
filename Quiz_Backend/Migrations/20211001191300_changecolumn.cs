using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz_Backend.Migrations
{
    public partial class changecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "Questions",
                newName: "question");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "question",
                table: "Questions",
                newName: "text");
        }
    }
}
