using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProyecto.Entities;

namespace TestProyecto.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySQL("Server=localhost; database=testp; user=root; password=;");


        }

        //public DbSet<Rol> Roles { get; set; }

        //public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Vendedor> Vendedores { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Sabor> Sabores { get; set; }

        public DbSet<Tamano> Tamanos { get; set; }

        public DbSet<Lote> Lotes { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<SuperAdmin> SuperAdministradores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleVenta>().HasKey(x => new { x.FkProducto, x.FkVenta });

            modelBuilder.Entity<DetalleVenta>().
                HasOne(x => x.Producto)
                .WithMany(y => y.ProductosVenta).
                HasForeignKey(x => x.FkProducto);
            modelBuilder.Entity<DetalleVenta>().
                HasOne(x => x.Venta).
                WithMany(y => y.ProductosVenta).
                HasForeignKey(x => x.FkVenta);

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    PkCliente = 1,
                    NombreCliente = "Juan",
                    ApellidoCliente = "Perez",
                    PasswordCliente = "123",
                    CorreoCliente = "arriba@gmail.com",
                    FkRol = 1
                }
                );
            modelBuilder.Entity<Rol>().HasData(
                new Rol {
                    PkRol = 1,
                    RolName = "Cliente"
                },
                new Rol
                {
                    PkRol = 2,
                    RolName = "Vendedor",

                },
                new Rol
                {
                    PkRol = 3,
                    RolName = "SA",
                }
                );
            modelBuilder.Entity<Tamano>().HasData(
                new Tamano
                {
                    PkTamano = 1,
                    TamanoP = "Chico"
                },
                new Tamano
                {
                    PkTamano = 2,
                    TamanoP = "Mediano"
                },
                new Tamano
                {
                    PkTamano = 3,
                    TamanoP = "Grande"
                }
                );
            modelBuilder.Entity<Lote>().HasData(
                new Lote
                {
                    PkLote = 1,
                    NomLote = 1
                },
                new Lote
                {
                    PkLote = 2,
                    NomLote = 2
                },
                new Lote
                {
                    PkLote = 3,
                    NomLote = 3
                },
                new Lote
                {
                    PkLote = 4,
                    NomLote = 4
                },
                new Lote
                {
                    PkLote = 5,
                    NomLote = 5
                },
                new Lote
                {
                    PkLote = 6,
                    NomLote = 6
                },
                new Lote
                {
                    PkLote = 7,
                    NomLote = 7
                },
                new Lote
                {
                    PkLote = 8,
                    NomLote = 8
                },
                new Lote
                {
                    PkLote = 9,
                    NomLote = 9
                }
                );
            modelBuilder.Entity<Sabor>().HasData(
                new Sabor
                {
                PkSabor = 1,
                NameSabor = "Natural",
                },
                new Sabor
                {
                    PkSabor = 2,
                    NameSabor = "Cola"
                },
                new Sabor
                {
                    PkSabor = 3,
                    NameSabor = "Naranja"
                },
                new Sabor
                {
                    PkSabor = 4,
                    NameSabor = "Limon"
                },
                new Sabor
                {
                    PkSabor = 5,
                    NameSabor = "Negro"
                },
                new Sabor
                {
                    PkSabor = 6,
                    NameSabor = "Lager",
                },
                new Sabor
                {
                    PkSabor = 7,
                    NameSabor = "Fresa",
                },
                new Sabor
                {
                    PkSabor = 8,
                    NameSabor = "Merlot"
                },
                new Sabor
                {
                    PkSabor =9,
                    NameSabor = "Pina"
                }
                );
        }
    }

}
