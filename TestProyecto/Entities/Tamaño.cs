using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Entities
{
    public class Tamaño
    {
        [Key]

        public int PkTamaño { get; set; }

        public string TamañoP {  get; set; }



    }
}
