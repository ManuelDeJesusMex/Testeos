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
        public DateTime FechaCompra { get; set; }

        public double Subtotal { get; set; }
        public double Total { get; set; }

       

        [ForeignKey(("Producto"))]            

        public int FkProducto { get;set; }
        public Producto Producto { get; set; }


        [ForeignKey(("Venta"))]

        public int FkVenta { get; set; } 
        public Venta Venta { get; set; }
    }
}
