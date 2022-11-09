using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_gcd.Data.Migrations
{
    public partial class AddIsFree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Chapters",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Chapters");
        }
    }
}
