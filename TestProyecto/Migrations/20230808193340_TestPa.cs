using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyecto.Migrations
{
    public partial class TestPa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVenta_Productos_FkProducto",
                table: "DetalleVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleVenta_Ventas_FkVenta",
                table: "DetalleVenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleVenta",
                table: "DetalleVenta");

            migrationBuilder.RenameTable(
                name: "DetalleVenta",
                newName: "detalleVentas");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleVenta_FkVenta",
                table: "detalleVentas",
                newName: "IX_detalleVentas_FkVenta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleVentas",
                table: "detalleVentas",
                columns: new[] { "FkProducto", "FkVenta" });

            migrationBuilder.AddForeignKey(
                name: "FK_detalleVentas_Productos_FkProducto",
                table: "detalleVentas",
                column: "FkProducto",
                principalTable: "Productos",
                principalColumn: "PkProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleVentas_Ventas_FkVenta",
                table: "detalleVentas",
                column: "FkVenta",
                principalTable: "Ventas",
                principalColumn: "PkCompra",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleVentas_Productos_FkProducto",
                table: "detalleVentas");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleVentas_Ventas_FkVenta",
                table: "detalleVentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleVentas",
                table: "detalleVentas");

            migrationBuilder.RenameTable(
                name: "detalleVentas",
                newName: "DetalleVenta");

            migrationBuilder.RenameIndex(
                name: "IX_detalleVentas_FkVenta",
                table: "DetalleVenta",
                newName: "IX_DetalleVenta_FkVenta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleVenta",
                table: "DetalleVenta",
                columns: new[] { "FkProducto", "FkVenta" });

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVenta_Productos_FkProducto",
                table: "DetalleVenta",
                column: "FkProducto",
                principalTable: "Productos",
                principalColumn: "PkProducto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleVenta_Ventas_FkVenta",
                table: "DetalleVenta",
                column: "FkVenta",
                principalTable: "Ventas",
                principalColumn: "PkCompra",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
