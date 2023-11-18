using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class QuizForignKeyUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_User_UserId",
                table: "Quiz",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_User_UserId",
                table: "Quiz");

            migrationBuilder.DropIndex(
                name: "IX_Quiz_UserId",
                table: "Quiz");
        }
    }
}
