using Microsoft.EntityFrameworkCore.Migrations;

namespace WEB_Core_Conv2.Migrations
{
    public partial class _25032022 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_IdCategoria",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_IdCategoria",
                table: "Producto",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
