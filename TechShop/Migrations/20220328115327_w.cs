using Microsoft.EntityFrameworkCore.Migrations;

namespace TechShop.Migrations
{
    public partial class w : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 3)");

            migrationBuilder.AddColumn<string>(
                name: "DetailedDescription",
                table: "Products",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailedDescription",
                table: "Products");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(8, 3)",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
