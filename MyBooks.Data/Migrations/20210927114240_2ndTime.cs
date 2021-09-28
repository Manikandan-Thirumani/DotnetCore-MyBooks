using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooks.Data.Migrations
{
    public partial class _2ndTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Authors",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
