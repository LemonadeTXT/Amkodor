using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amkodor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSomeModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Warehouses_WarehouseId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsSuppliers_Suppliers_SupplierId",
                table: "MaterialsSuppliers");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "MaterialsSuppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "Materials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Warehouses_WarehouseId",
                table: "Materials",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsSuppliers_Suppliers_SupplierId",
                table: "MaterialsSuppliers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Warehouses_WarehouseId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialsSuppliers_Suppliers_SupplierId",
                table: "MaterialsSuppliers");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "MaterialsSuppliers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WarehouseId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Warehouses_WarehouseId",
                table: "Materials",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialsSuppliers_Suppliers_SupplierId",
                table: "MaterialsSuppliers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
