using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MouseHouse.Data.Migrations
{
    public partial class OrderNumberKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 160, nullable: true),
                    LastName = table.Column<string>(maxLength: 160, nullable: true),
                    Address = table.Column<string>(maxLength: 70, nullable: true),
                    City = table.Column<string>(maxLength: 70, nullable: true),
                    State = table.Column<string>(maxLength: 70, nullable: true),
                    ZIPCode = table.Column<string>(maxLength: 70, nullable: true),
                    Country = table.Column<string>(maxLength: 70, nullable: true),
                    Phone = table.Column<string>(maxLength: 70, nullable: true),
                    Email = table.Column<string>(maxLength: 160, nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderNumber",
                table: "Products",
                column: "OrderNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderNumber",
                table: "Products",
                column: "OrderNumber",
                principalTable: "Orders",
                principalColumn: "OrderNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderNumber",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderNumber",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Products");
        }
    }
}
