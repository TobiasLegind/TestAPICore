using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAPICore.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "ArticleItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Headline = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleItems_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "George", "RR Martin" },
                    { 2, "Stephen", "Fry" },
                    { 3, "James", "Ellroy" },
                    { 4, "Douglas", "Adams" }
                });

            migrationBuilder.InsertData(
                table: "ArticleItems",
                columns: new[] { "Id", "AuthorId", "Date", "Headline", "Text" },
                values: new object[] { 1, 2, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eksperter: Det har nul effekt på smitten i Danmark at lukke grænsen nu", "Tidligere direktør for Sundhedsstyrelsen kritiserer historisk beslutning om at lukke de danske grænser. Det er uklart, hvilke anbefalinger regeringen har bygget beslutningen om at lukke grænserne på." });

            migrationBuilder.InsertData(
                table: "ArticleItems",
                columns: new[] { "Id", "AuthorId", "Date", "Headline", "Text" },
                values: new object[] { 2, 4, new DateTime(1979, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hitchhiker's Guide to the Galaxy", "econds before the Earth is demolished to make way for a galactic freeway, Arthur Dent is plucked off the planet by his friend Ford Prefect, a researcher for the revised edition of The Hitchhiker's Guide to the Galaxy who, for the last fifteen years, has been posing as an out-of-work actor." });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleItems_AuthorId",
                table: "ArticleItems",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleItems");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
