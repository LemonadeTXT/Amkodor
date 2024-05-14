using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amkodor.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InManufacturing",
                table: "ProductsInManufacturing",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InManufacturing",
                table: "ProductsInManufacturing");
        }
    }
}
