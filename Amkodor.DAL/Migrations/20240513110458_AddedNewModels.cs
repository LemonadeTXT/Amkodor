using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amkodor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ProductInBuilding_ProductInBuildingId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInBuilding",
                table: "ProductInBuilding");

            migrationBuilder.RenameTable(
                name: "ProductInBuilding",
                newName: "ProductsInBuilding");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsInBuilding",
                table: "ProductsInBuilding",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "money", nullable: true),
                    BuildDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ProductsInBuilding_ProductInBuildingId",
                table: "Employees",
                column: "ProductInBuildingId",
                principalTable: "ProductsInBuilding",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ProductsInBuilding_ProductInBuildingId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsInBuilding",
                table: "ProductsInBuilding");

            migrationBuilder.RenameTable(
                name: "ProductsInBuilding",
                newName: "ProductInBuilding");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInBuilding",
                table: "ProductInBuilding",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ProductInBuilding_ProductInBuildingId",
                table: "Employees",
                column: "ProductInBuildingId",
                principalTable: "ProductInBuilding",
                principalColumn: "Id");
        }
    }
}
