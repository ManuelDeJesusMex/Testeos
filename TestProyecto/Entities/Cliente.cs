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

        public string NombreCliente { get; set; }

        public string ApellidoCliente { get; set; }

        public string CorreoCliente { get; set; }

        public string PasswordCliente { get; set; }

        public double SaldoCliente { get; set; }

        [ForeignKey(("Roles"))]

        public int? FkRol { get; set; }

        public Rol Roles { get; set; }

    }
}
