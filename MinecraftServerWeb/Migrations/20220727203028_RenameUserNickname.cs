using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinecraftServerWeb.Migrations
{
    public partial class RenameUserNickname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Users",
                newName: "PublicNickname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicNickname",
                table: "Users",
                newName: "Nickname");
        }
    }
}
