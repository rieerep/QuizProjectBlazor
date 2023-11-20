using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorQuiz.Server.Migrations
{
    public partial class timermig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Timer",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timer",
                table: "Questions");
        }
    }
}
