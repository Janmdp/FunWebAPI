using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class localDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Users_AcceptUserId",
                table: "Trades");

            migrationBuilder.AlterColumn<int>(
                name: "AcceptUserId",
                table: "Trades",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Users_AcceptUserId",
                table: "Trades",
                column: "AcceptUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Users_AcceptUserId",
                table: "Trades");

            migrationBuilder.AlterColumn<int>(
                name: "AcceptUserId",
                table: "Trades",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Users_AcceptUserId",
                table: "Trades",
                column: "AcceptUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
