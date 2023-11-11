using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Migrations
{
    public partial class InitialV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarberServices",
                columns: table => new
                {
                    BarberServiceID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberServiceFIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarberServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarberServiceImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberServices", x => x.BarberServiceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarberServices");
        }
    }
}
