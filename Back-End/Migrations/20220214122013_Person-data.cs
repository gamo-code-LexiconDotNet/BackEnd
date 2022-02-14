using Microsoft.EntityFrameworkCore.Migrations;

namespace Back_End.Migrations
{
    public partial class Persondata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Amsterdam", "Alice", "1234567890" },
                    { 2, "Berlin", "Bob", "2345679801" },
                    { 3, "Copenhagen", "Carol", "3456789012" },
                    { 4, "Dublin", "Dan", "4567890123" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
