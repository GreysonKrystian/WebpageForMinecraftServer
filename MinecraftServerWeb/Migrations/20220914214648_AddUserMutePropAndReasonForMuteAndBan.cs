using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinecraftServerWeb.Migrations
{
    public partial class AddUserMutePropAndReasonForMuteAndBan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMuted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LockReason",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MuteEndDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MuteReason",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMuted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockReason",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MuteEndDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MuteReason",
                table: "Users");
        }
    }
}
