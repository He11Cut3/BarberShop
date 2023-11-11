using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Migrations
{
    public partial class InitialV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarberStocks",
                columns: table => new
                {
                    BarberStockID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberStockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarberStockDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarberStockImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberStocks", x => x.BarberStockID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarberStocks");
        }
    }
}
