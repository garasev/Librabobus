using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Librabobus.Backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Librabobus");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Librabobus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    About = table.Column<string>(type: "text", nullable: true),
                    PhotoBase64 = table.Column<string>(type: "text", nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                schema: "Librabobus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Privat = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PhotoBase64 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Librabobus",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "Librabobus",
                columns: table => new
                {
                    UserFromId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserToId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => new { x.UserFromId, x.UserToId });
                    table.ForeignKey(
                        name: "FK_Subscription_User_UserFromId",
                        column: x => x.UserFromId,
                        principalSchema: "Librabobus",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscription_User_UserToId",
                        column: x => x.UserToId,
                        principalSchema: "Librabobus",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                schema: "Librabobus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    KeyWords = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Record_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Librabobus",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedSubject",
                schema: "Librabobus",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedSubject", x => new { x.UserId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_SavedSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "Librabobus",
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedSubject_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Librabobus",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Record_Id",
                schema: "Librabobus",
                table: "Record",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Record_SubjectId",
                schema: "Librabobus",
                table: "Record",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedSubject_SubjectId",
                schema: "Librabobus",
                table: "SavedSubject",
                column: "SubjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedSubject_UserId",
                schema: "Librabobus",
                table: "SavedSubject",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Id",
                schema: "Librabobus",
                table: "Subject",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_OwnerId",
                schema: "Librabobus",
                table: "Subject",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_UserFromId",
                schema: "Librabobus",
                table: "Subscription",
                column: "UserFromId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_UserToId",
                schema: "Librabobus",
                table: "Subscription",
                column: "UserToId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                schema: "Librabobus",
                table: "User",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Record",
                schema: "Librabobus");

            migrationBuilder.DropTable(
                name: "SavedSubject",
                schema: "Librabobus");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "Librabobus");

            migrationBuilder.DropTable(
                name: "Subject",
                schema: "Librabobus");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Librabobus");
        }
    }
}
