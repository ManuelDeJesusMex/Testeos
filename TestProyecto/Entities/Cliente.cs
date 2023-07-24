using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Entities
{
    public class Cliente
    {

        [Key]
        public int PkCliente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Correo { get; set; }

        public string Password { get; set; }

        public double Saldo { get; set; }

        [ForeignKey(("Roles"))]

        public int? FkRol { get; set; }

        public Rol Roles { get; set; }

    }
}
