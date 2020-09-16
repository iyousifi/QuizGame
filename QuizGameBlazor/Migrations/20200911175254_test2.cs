using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizGameBlazor.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerOptions_Answers_AnswerId",
                table: "AnswerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerOptions_Questions_QuestionId",
                table: "AnswerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerTags_Answers_AnswerId",
                table: "AnswerTags");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerTags_Tags_TagId",
                table: "AnswerTags");

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
                name: "FK_AnswerTags_Tags_AnswerId",
                table: "AnswerTags",
                column: "AnswerId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerTags_Answers_TagId",
                table: "AnswerTags",
                column: "TagId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerOptions_Questions_AnswerId",
                table: "AnswerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerOptions_Answers_QuestionId",
                table: "AnswerOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerTags_Tags_AnswerId",
                table: "AnswerTags");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerTags_Answers_TagId",
                table: "AnswerTags");

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
                name: "FK_AnswerTags_Answers_AnswerId",
                table: "AnswerTags",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerTags_Tags_TagId",
                table: "AnswerTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
