using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_app_gcd.Data.Migrations
{
    public partial class AddAccesses2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesses_AspNetUsers_UserId1",
                table: "Accesses");

            migrationBuilder.DropIndex(
                name: "IX_Accesses_UserId1",
                table: "Accesses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Accesses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Accesses",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Accesses_UserId",
                table: "Accesses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accesses_AspNetUsers_UserId",
                table: "Accesses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesses_AspNetUsers_UserId",
                table: "Accesses");

            migrationBuilder.DropIndex(
                name: "IX_Accesses_UserId",
                table: "Accesses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Accesses",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Accesses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accesses_UserId1",
                table: "Accesses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Accesses_AspNetUsers_UserId1",
                table: "Accesses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
