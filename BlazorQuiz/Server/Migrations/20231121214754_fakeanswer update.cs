using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorQuiz.Server.Migrations
{
    public partial class fakeanswerupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FakeAnswers_Questions_QuestionModelId",
                table: "FakeAnswers");

            migrationBuilder.RenameColumn(
                name: "QuestionModelId",
                table: "FakeAnswers",
                newName: "QuestionsId");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "FakeAnswers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_FakeAnswers_QuestionModelId",
                table: "FakeAnswers",
                newName: "IX_FakeAnswers_QuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FakeAnswers_Questions_QuestionsId",
                table: "FakeAnswers",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FakeAnswers_Questions_QuestionsId",
                table: "FakeAnswers");

            migrationBuilder.RenameColumn(
                name: "QuestionsId",
                table: "FakeAnswers",
                newName: "QuestionModelId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "FakeAnswers",
                newName: "Question");

            migrationBuilder.RenameIndex(
                name: "IX_FakeAnswers_QuestionsId",
                table: "FakeAnswers",
                newName: "IX_FakeAnswers_QuestionModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FakeAnswers_Questions_QuestionModelId",
                table: "FakeAnswers",
                column: "QuestionModelId",
                principalTable: "Questions",
                principalColumn: "Id");
        }
    }
}
