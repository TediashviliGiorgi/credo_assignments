using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.API.Migrations
{
    /// <inheritdoc />
    public partial class addTodoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Todos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Todos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TodoStatus",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "TodoStatus",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todos");
        }
    }
}
