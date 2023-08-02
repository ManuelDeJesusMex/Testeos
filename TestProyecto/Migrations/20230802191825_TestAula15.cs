using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProyecto.Migrations
{
    public partial class TestAula15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SuperAdministradores",
                columns: new[] { "PkSuperAdmin", "ApellidoSuperAdmin", "ContraseñaSuperAdmin", "CorreoSuperAdmin", "FkRol", "NombreSuperAdmin" },
                values: new object[] { 1, "Gutierrez", "123", "Felipe@gmail.com", 3, "Felipe" });

            migrationBuilder.InsertData(
                table: "Vendedores",
                columns: new[] { "PkVendedor", "ApellidoVendedor", "ContraseñaVendedor", "CorreoV", "FkRol", "NombreVendedor" },
                values: new object[,]
                {
                    { 1, "Gonzalez", "546546", "juan.gonzalez@gmail.com", 2, "Juan" },
                    { 2, "Silva", "564643", "maria.silva@gmail.com", 2, "Maria" },
                    { 3, "Rojas", "234324", "cristian.rojas@gmail.com", 2, "Cristian" },
                    { 4, "Perez", "123", "diablo@gmail.com", 3, "Leonardo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuperAdministradores",
                keyColumn: "PkSuperAdmin",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "PkVendedor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "PkVendedor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "PkVendedor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vendedores",
                keyColumn: "PkVendedor",
                keyValue: 4);
        }
    }
}
