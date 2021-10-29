using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz_Backend.Migrations
{
    public partial class addingnewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "answer1",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "answer2",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "answer3",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "answer1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "answer2",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "answer3",
                table: "Questions");
        }
    }
}
