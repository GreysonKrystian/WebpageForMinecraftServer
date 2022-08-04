using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinecraftServerWeb.Migrations
{
    public partial class AddForumNicknameToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForumNickname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForumNickname",
                table: "Users");
        }
    }
}
