using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizGameBlazor.Migrations
{
    public partial class Fixedforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddForeignKey(
                name: "FK_AnswerOptions_Answers_AnswerId",
                table: "AnswerOptions",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerOptions_Questions_QuestionId",
                table: "AnswerOptions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTags_Questions_QuestionId",
                table: "QuestionTags",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTags_Tags_TagId",
                table: "QuestionTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerOptions_Answers_AnswerId",
                table: "AnswerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerOptions_Questions_QuestionId",
                table: "AnswerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTags_Questions_QuestionId",
                table: "QuestionTags");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionTags_Tags_TagId",
                table: "QuestionTags");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerOptions_Questions_AnswerId",
                table: "AnswerOptions",
                column: "AnswerId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerOptions_Answers_QuestionId",
                table: "AnswerOptions",
                column: "QuestionId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTags_Tags_QuestionId",
                table: "QuestionTags",
                column: "QuestionId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionTags_Questions_TagId",
                table: "QuestionTags",
                column: "TagId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
