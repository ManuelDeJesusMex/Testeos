using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Entities
{
    public class Rol
    {

        [Key]

        public int PkRol { get; set; } 

        public string RolName { get; set; }

    }
}
