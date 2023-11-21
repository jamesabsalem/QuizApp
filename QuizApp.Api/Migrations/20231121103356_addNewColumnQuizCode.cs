using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class addNewColumnQuizCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuizCode",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT('QZ-', CONVERT(NVARCHAR(20), [QuizId]))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuizCode",
                table: "Quiz");
        }
    }
}
