using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_Core_Conv2.Migrations
{
    public partial class migrationProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    IdModulo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPropietario = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.IdModulo);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Precio = table.Column<float>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
