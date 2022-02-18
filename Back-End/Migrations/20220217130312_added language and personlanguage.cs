using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_End.Migrations
{
    public partial class addedlanguageandpersonlanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 48, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeopleLanguages",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleLanguages", x => new { x.PersonId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PeopleLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleLanguages_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dutch" },
                    { 2, "German" },
                    { 3, "Danish" },
                    { 4, "Irish" }
                });

            migrationBuilder.InsertData(
                table: "PeopleLanguages",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleLanguages_LanguageId",
                table: "PeopleLanguages",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleLanguages");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
