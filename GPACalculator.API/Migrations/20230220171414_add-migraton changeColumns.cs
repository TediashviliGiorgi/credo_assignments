using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPACalculator.API.Migrations
{
    /// <inheritdoc />
    public partial class addmigratonchangeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrivateNumber",
                table: "Students",
                newName: "PersonalNumber");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Students",
                newName: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalNumber",
                table: "Students",
                newName: "PrivateNumber");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "Students",
                newName: "CourseName");
        }
    }
}
