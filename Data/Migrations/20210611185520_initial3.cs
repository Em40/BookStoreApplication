using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApplication.Data.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magazines_Publishers_PublisherId",
                table: "Magazines");

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "Magazines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Magazines_Publishers_PublisherId",
                table: "Magazines",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magazines_Publishers_PublisherId",
                table: "Magazines");

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "Magazines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Magazines_Publishers_PublisherId",
                table: "Magazines",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
