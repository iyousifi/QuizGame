using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizGameBlazor.Migrations
{
    public partial class QuestionTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionTags",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTags", x => new { x.QuestionId, x.TagId });
                    table.ForeignKey(
                        name: "FK_QuestionTags_Tags_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionTags_Questions_TagId",
                        column: x => x.TagId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTags_TagId",
                table: "QuestionTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionTags");
        }
    }
}
