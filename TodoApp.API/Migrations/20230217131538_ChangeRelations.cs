using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Todos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserEntityId",
                table: "Todos",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Users_UserEntityId",
                table: "Todos",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Users_UserEntityId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_UserEntityId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Todos");
        }
    }
}
