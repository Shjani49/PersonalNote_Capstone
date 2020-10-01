using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalNotes.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_User",
                table: "notes");

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "ID", "email", "fname", "lname", "password" },
                values: new object[] { -1, "sjani@ualberta.ca", "Shivani", "Jani", "abc@123" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "ID", "email", "fname", "lname", "password" },
                values: new object[] { -2, "shailza@ualberta.ca", "Shailza", "Sharma", "xyz@123" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "ID", "email", "fname", "lname", "password" },
                values: new object[] { -3, "hkour@ualberta.ca", "Harpreet", "Kour", "pqr@123" });

            migrationBuilder.InsertData(
                table: "notes",
                columns: new[] { "ID", "date", "Note", "UserId" },
                values: new object[] { -1, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", -1 });

            migrationBuilder.InsertData(
                table: "notes",
                columns: new[] { "ID", "date", "Note", "UserId" },
                values: new object[] { -2, new DateTime(2020, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", -2 });

            migrationBuilder.InsertData(
                table: "notes",
                columns: new[] { "ID", "date", "Note", "UserId" },
                values: new object[] { -3, new DateTime(2020, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", -3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_User",
                table: "notes",
                column: "UserId",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_User",
                table: "notes");

            migrationBuilder.DeleteData(
                table: "notes",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "notes",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "notes",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_User",
                table: "notes",
                column: "UserId",
                principalTable: "user",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
