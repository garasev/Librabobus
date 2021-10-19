using Microsoft.EntityFrameworkCore.Migrations;

namespace Librabobus.Backend.Migrations
{
    public partial class UserLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                schema: "Librabobus",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_Login",
                schema: "Librabobus",
                table: "User",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Login",
                schema: "Librabobus",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Login",
                schema: "Librabobus",
                table: "User");
        }
    }
}
