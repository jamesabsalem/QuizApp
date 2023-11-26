using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class noChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuizCode",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT('QZ-', CONVERT(NVARCHAR(20), [QuizId]))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "CONCAT('QZ-', CONVERT(NVARCHAR(20), [QuizId]))");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuizCode",
                table: "Quiz",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "CONCAT('QZ-', CONVERT(NVARCHAR(20), [QuizId]))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONCAT('QZ-', CONVERT(NVARCHAR(20), [QuizId]))");
        }
    }
}
