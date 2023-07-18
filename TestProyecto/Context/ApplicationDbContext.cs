using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySQL("Server=localhost; database=Testeo; user=root; password=arenaquesito;");


        }

        //public DbSet<Rol> Roles { get; set; }

        //public DbSet<Usuario> Usuarios { get; set; }
    }

}
