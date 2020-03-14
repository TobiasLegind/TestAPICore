using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPICore.Migrations
{
    public partial class MovedAuthorToSeperateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "ArticleItems");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "ArticleItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AuthorItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AuthorItems",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "George", "RR Martin" },
                    { 2, "Stephen", "Fry" },
                    { 3, "James", "Elroy" },
                    { 4, "Douglas", "Adams" }
                });

            migrationBuilder.InsertData(
                table: "ArticleItems",
                columns: new[] { "Id", "AuthorId", "Date", "Headline", "Text" },
                values: new object[] { 1, 1, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eksperter: Det har nul effekt på smitten i Danmark at lukke grænsen nu", "Tidligere direktør for Sundhedsstyrelsen kritiserer historisk beslutning om at lukke de danske grænser. Det er uklart, hvilke anbefalinger regeringen har bygget beslutningen om at lukke grænserne på." });

            migrationBuilder.InsertData(
                table: "ArticleItems",
                columns: new[] { "Id", "AuthorId", "Date", "Headline", "Text" },
                values: new object[] { 2, 4, new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hitchhiker's Guide to the Galaxy", "econds before the Earth is demolished to make way for a galactic freeway, Arthur Dent is plucked off the planet by his friend Ford Prefect, a researcher for the revised edition of The Hitchhiker's Guide to the Galaxy who, for the last fifteen years, has been posing as an out-of-work actor." });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleItems_AuthorId",
                table: "ArticleItems",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleItems_AuthorItems_AuthorId",
                table: "ArticleItems",
                column: "AuthorId",
                principalTable: "AuthorItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleItems_AuthorItems_AuthorId",
                table: "ArticleItems");

            migrationBuilder.DropTable(
                name: "AuthorItems");

            migrationBuilder.DropIndex(
                name: "IX_ArticleItems_AuthorId",
                table: "ArticleItems");

            migrationBuilder.DeleteData(
                table: "ArticleItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticleItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ArticleItems");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "ArticleItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
