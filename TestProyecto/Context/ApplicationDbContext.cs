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

            optionsBuilder.UseMySQL("Server=localhost; database=Testproyecto; user=root; password=;");


        }

        //public DbSet<Rol> Roles { get; set; }

        //public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Vendedor> Vendedores { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Sabor> Sabores { get; set; }

        public DbSet<Tamaño> Tamaños { get; set; }

        public DbSet<Lote> Lotes { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<SuperAdmin> SuperAdministradores { get; set; }

    }

}
