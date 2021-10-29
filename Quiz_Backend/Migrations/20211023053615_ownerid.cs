using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz_Backend.Migrations
{
    public partial class ownerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ownerid",
                table: "Quizes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ownerid",
                table: "Quizes");
        }
    }
}
