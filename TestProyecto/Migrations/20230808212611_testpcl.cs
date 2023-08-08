using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace TestProyecto.Migrations
{
    public partial class testpcl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    PkLote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NomLote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.PkLote);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RolName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "Sabores",
                columns: table => new
                {
                    PkSabor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameSabor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabores", x => x.PkSabor);
                });

            migrationBuilder.CreateTable(
                name: "Tamanos",
                columns: table => new
                {
                    PkTamano = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TamanoP = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamanos", x => x.PkTamano);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    PkCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreCliente = table.Column<string>(type: "text", nullable: false),
                    ApellidoCliente = table.Column<string>(type: "text", nullable: false),
                    CorreoCliente = table.Column<string>(type: "text", nullable: false),
                    PasswordCliente = table.Column<string>(type: "text", nullable: false),
                    SaldoCliente = table.Column<double>(type: "double", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.PkCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuperAdministradores",
                columns: table => new
                {
                    PkSuperAdmin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreSuperAdmin = table.Column<string>(type: "text", nullable: false),
                    ApellidoSuperAdmin = table.Column<string>(type: "text", nullable: false),
                    CorreoSuperAdmin = table.Column<string>(type: "text", nullable: false),
                    ContraseñaSuperAdmin = table.Column<string>(type: "text", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAdministradores", x => x.PkSuperAdmin);
                    table.ForeignKey(
                        name: "FK_SuperAdministradores_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    PkVendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NombreVendedor = table.Column<string>(type: "text", nullable: false),
                    ApellidoVendedor = table.Column<string>(type: "text", nullable: false),
                    CorreoV = table.Column<string>(type: "text", nullable: false),
                    ContraseñaVendedor = table.Column<string>(type: "text", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.PkVendedor);
                    table.ForeignKey(
                        name: "FK_Vendedores_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    PkCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FechaCompra = table.Column<DateTime>(type: "datetime", nullable: false),
                    FkCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.PkCompra);
                    table.ForeignKey(
                        name: "FK_Ventas_Clientes_FkCliente",
                        column: x => x.FkCliente,
                        principalTable: "Clientes",
                        principalColumn: "PkCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    PkProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "double", nullable: false),
                    FkVendedor = table.Column<int>(type: "int", nullable: false),
                    FkLote = table.Column<int>(type: "int", nullable: true),
                    FkSabor = table.Column<int>(type: "int", nullable: false),
                    FkTamano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.PkProducto);
                    table.ForeignKey(
                        name: "FK_Productos_Lotes_FkLote",
                        column: x => x.FkLote,
                        principalTable: "Lotes",
                        principalColumn: "PkLote",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Sabores_FkSabor",
                        column: x => x.FkSabor,
                        principalTable: "Sabores",
                        principalColumn: "PkSabor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Tamanos_FkTamano",
                        column: x => x.FkTamano,
                        principalTable: "Tamanos",
                        principalColumn: "PkTamano",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Vendedores_FkVendedor",
                        column: x => x.FkVendedor,
                        principalTable: "Vendedores",
                        principalColumn: "PkVendedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalleVentas",
                columns: table => new
                {
                    FkProducto = table.Column<int>(type: "int", nullable: false),
                    FkVenta = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime", nullable: false),
                    Subtotal = table.Column<double>(type: "double", nullable: false),
                    Total = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleVentas", x => new { x.FkProducto, x.FkVenta });
                    table.ForeignKey(
                        name: "FK_detalleVentas_Productos_FkProducto",
                        column: x => x.FkProducto,
                        principalTable: "Productos",
                        principalColumn: "PkProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleVentas_Ventas_FkVenta",
                        column: x => x.FkVenta,
                        principalTable: "Ventas",
                        principalColumn: "PkCompra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoVenta",
                columns: table => new
                {
                    ProductosPkProducto = table.Column<int>(type: "int", nullable: false),
                    VentasPkCompra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoVenta", x => new { x.ProductosPkProducto, x.VentasPkCompra });
                    table.ForeignKey(
                        name: "FK_ProductoVenta_Productos_ProductosPkProducto",
                        column: x => x.ProductosPkProducto,
                        principalTable: "Productos",
                        principalColumn: "PkProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoVenta_Ventas_VentasPkCompra",
                        column: x => x.VentasPkCompra,
                        principalTable: "Ventas",
                        principalColumn: "PkCompra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lotes",
                columns: new[] { "PkLote", "NomLote" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "PkRol", "RolName" },
                values: new object[,]
                {
                    { 2, "Vendedor" },
                    { 3, "SA" },
                    { 1, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Sabores",
                columns: new[] { "PkSabor", "NameSabor" },
                values: new object[,]
                {
                    { 1, "Natural" },
                    { 2, "Cola" },
                    { 3, "Naranja" },
                    { 4, "Limon" },
                    { 5, "Negro" },
                    { 6, "Lager" },
                    { 7, "Fresa" },
                    { 8, "Merlot" },
                    { 9, "Pina" }
                });

            migrationBuilder.InsertData(
                table: "Tamanos",
                columns: new[] { "PkTamano", "TamanoP" },
                values: new object[,]
                {
                    { 2, "Mediano" },
                    { 1, "Chico" },
                    { 3, "Grande" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "PkCliente", "ApellidoCliente", "CorreoCliente", "FkRol", "NombreCliente", "PasswordCliente", "SaldoCliente" },
                values: new object[] { 1, "Perez", "arriba@gmail.com", 1, "Juan", "123", 0.0 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FkRol",
                table: "Clientes",
                column: "FkRol");

            migrationBuilder.CreateIndex(
                name: "IX_detalleVentas_FkVenta",
                table: "detalleVentas",
                column: "FkVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkLote",
                table: "Productos",
                column: "FkLote");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkSabor",
                table: "Productos",
                column: "FkSabor");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkTamano",
                table: "Productos",
                column: "FkTamano");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkVendedor",
                table: "Productos",
                column: "FkVendedor");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoVenta_VentasPkCompra",
                table: "ProductoVenta",
                column: "VentasPkCompra");

            migrationBuilder.CreateIndex(
                name: "IX_SuperAdministradores_FkRol",
                table: "SuperAdministradores",
                column: "FkRol");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedores_FkRol",
                table: "Vendedores",
                column: "FkRol");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_FkCliente",
                table: "Ventas",
                column: "FkCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleVentas");

            migrationBuilder.DropTable(
                name: "ProductoVenta");

            migrationBuilder.DropTable(
                name: "SuperAdministradores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Sabores");

            migrationBuilder.DropTable(
                name: "Tamanos");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
