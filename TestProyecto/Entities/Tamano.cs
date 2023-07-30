using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Entities
{
    public class Tamano
    {
        [Key]

        public int PkTamano { get; set; }

        public string TamanoP {  get; set; }



    }
}
