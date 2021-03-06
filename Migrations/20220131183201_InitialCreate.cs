using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTiempo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiempoItem",
                columns: table => new
                {
                    Municipio = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperatura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempMax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempMin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempMedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Humedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VelocidadViento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecipitacionAcumulada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitud = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiempoItem", x => x.Municipio);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiempoItem");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
