using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Entities
{
    public class SuperAdmin
    {
        [Key]

        public int PkSuperAdmin { get; set; }

        public string NombreSuperAdmin { get; set; }

        public string ApellidoSuperAdmin { get; set; }

        public string CorreoSuperAdmin { get; set; }

        public string ContraseñaSuperAdmin { get; set; }

        [ForeignKey(("Roles"))]

        public int? FkRol { set; get; }

        public Rol Roles { set; get; }
        //SADSA


        //ds
    }
}
