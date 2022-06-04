using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torpedo.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eredmenyek",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElsoJatekosNeve = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasodikJatekosNeve = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nyertes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElsoJatekosTalalata = table.Column<int>(type: "int", nullable: false),
                    MasodikJatekosTalalata = table.Column<int>(type: "int", nullable: false),
                    KorokSzama = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eredmenyek", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eredmenyek");
        }
    }
}
