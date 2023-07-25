using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace TestProyecto.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    PkLote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LoteName = table.Column<string>(type: "text", nullable: false)
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
                name: "Tamaños",
                columns: table => new
                {
                    PkTamaño = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TamañoP = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamaños", x => x.PkTamaño);
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
                    FkTamaño = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Productos_Tamaños_FkTamaño",
                        column: x => x.FkTamaño,
                        principalTable: "Tamaños",
                        principalColumn: "PkTamaño",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Vendedores_FkVendedor",
                        column: x => x.FkVendedor,
                        principalTable: "Vendedores",
                        principalColumn: "PkVendedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    PkCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FechaCompra = table.Column<DateTime>(type: "datetime", nullable: false),
                    FkCliente = table.Column<int>(type: "int", nullable: true),
                    FkVendedor = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Ventas_Vendedores_FkVendedor",
                        column: x => x.FkVendedor,
                        principalTable: "Vendedores",
                        principalColumn: "PkVendedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FkRol",
                table: "Clientes",
                column: "FkRol");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkLote",
                table: "Productos",
                column: "FkLote");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkSabor",
                table: "Productos",
                column: "FkSabor");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkTamaño",
                table: "Productos",
                column: "FkTamaño");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FkVendedor",
                table: "Productos",
                column: "FkVendedor");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedores_FkRol",
                table: "Vendedores",
                column: "FkRol");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_FkCliente",
                table: "Ventas",
                column: "FkCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_FkVendedor",
                table: "Ventas",
                column: "FkVendedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "Sabores");

            migrationBuilder.DropTable(
                name: "Tamaños");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
