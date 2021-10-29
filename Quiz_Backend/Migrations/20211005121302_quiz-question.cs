using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz_Backend.Migrations
{
    public partial class quizquestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdQuiz",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdQuiz",
                table: "Questions",
                column: "IdQuiz");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizes_IdQuiz",
                table: "Questions",
                column: "IdQuiz",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizes_IdQuiz",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_IdQuiz",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IdQuiz",
                table: "Questions");
        }
    }
}
