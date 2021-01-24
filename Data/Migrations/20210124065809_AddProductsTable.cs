using Microsoft.EntityFrameworkCore.Migrations;

namespace MouseHouse.Data.Migrations
{
    public partial class AddProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    Width = table.Column<double>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
