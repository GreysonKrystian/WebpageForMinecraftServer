using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinecraftServerWeb.Migrations
{
    public partial class MergeUserTableWithIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId1",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "AspNetUsers",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "User");

            migrationBuilder.AddColumn<string>(
                name: "ServerNickname",
                table: "AspNetUsers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId1",
                table: "Posts",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId1",
                table: "Posts",
                column: "AuthorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AuthorId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ServerNickname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    PublicNickname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Rank = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, defaultValue: "User")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
