using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorQuiz.Server.Migrations
{
    public partial class nullcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Media",
                table: "Questions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Media",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
