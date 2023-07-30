using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Entities
{
    public class Venta
    {


        public Venta() {
        
            ProductosVenta = new List<DetalleVenta>();

        }

        

        [Key]

        public int PkCompra { get; set; }

        public DateTime FechaCompra { get; set; }

        [ForeignKey(("Clientes"))]

        public int? FkCliente { get; set; }

        public Cliente Clientes { get; set; }

        public List<Producto> Productos { get; set; }

        public ICollection<DetalleVenta> ProductosVenta { get; set; }



        //[ForeignKey(("Vendedores"))]

        //public int? FkVendedor { get; set; }

        //public Vendedor Vendedores { get; set; }
    }
}
