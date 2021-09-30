using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBooks.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_BookAuthorId",
                table: "Books",
                column: "BookAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_BookAuthorId",
                table: "Books",
                column: "BookAuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_BookAuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookAuthorId",
                table: "Books");
        }
    }
}
