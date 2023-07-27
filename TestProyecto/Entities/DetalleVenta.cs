using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Entities
{
    public class DetalleVenta
    {
        //public DateTime

        [ForeignKey(("Productos"))]            

        public int FkProductos { get;set; }
        public Producto Productos { get; set; }


        [ForeignKey(("DetalleVentas"))]

        public int FkDetalleVenta { get; set; } 
        public DetalleVenta DetalleVentas { get; set; }
    }
}
