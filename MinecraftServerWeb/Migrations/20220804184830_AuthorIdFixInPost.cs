using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinecraftServerWeb.Migrations
{
    public partial class AuthorIdFixInPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");


            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Posts",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId1",
                table: "Posts",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorId1",
                table: "Posts",
                column: "AuthorId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
