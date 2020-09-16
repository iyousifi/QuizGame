using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizGameBlazor.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_AnswerId",
                table: "Tags",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Answers_AnswerId",
                table: "Tags",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
