using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreApplication.Data.Migrations
{
    public partial class FinalOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_Brands_BrandId",
                table: "Notebooks");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeSupplies_Brands_BrandId",
                table: "OfficeSupplies");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "OfficeSupplies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Notebooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_Brands_BrandId",
                table: "Notebooks",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeSupplies_Brands_BrandId",
                table: "OfficeSupplies",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_Brands_BrandId",
                table: "Notebooks");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeSupplies_Brands_BrandId",
                table: "OfficeSupplies");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "OfficeSupplies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Notebooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_Brands_BrandId",
                table: "Notebooks",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeSupplies_Brands_BrandId",
                table: "OfficeSupplies",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
