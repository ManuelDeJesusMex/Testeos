using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Entities
{
    public class Vendedor
    {
        [Key]

        public int PkVendedor { get; set; }

        public string NombreVendedor { get; set; }

        public string ApellidoVendedor { get; set; }

        public string CorreoV { get; set; }

        public string ContraseñaVendedor { get; set; }


    }
}
