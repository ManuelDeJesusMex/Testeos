using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyecto.Migrations
{
    public partial class testp3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Tamaños_FkTamano",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tamaños",
                table: "Tamaños");

            migrationBuilder.RenameTable(
                name: "Tamaños",
                newName: "Tamanos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tamanos",
                table: "Tamanos",
                column: "PkTamano");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Tamanos_FkTamano",
                table: "Productos",
                column: "FkTamano",
                principalTable: "Tamanos",
                principalColumn: "PkTamano",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Tamanos_FkTamano",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tamanos",
                table: "Tamanos");

            migrationBuilder.RenameTable(
                name: "Tamanos",
                newName: "Tamaños");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tamaños",
                table: "Tamaños",
                column: "PkTamano");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Tamaños_FkTamano",
                table: "Productos",
                column: "FkTamano",
                principalTable: "Tamaños",
                principalColumn: "PkTamano",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
