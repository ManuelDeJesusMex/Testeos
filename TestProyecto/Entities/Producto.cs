using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProyecto.Entities
{
    public class Producto
    {
        [Key]

        public int PkProducto { get; set; }

        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        public string Sabor { get; set; }

        public string Tamaño { get; set; }

        public string Lote { get; set; }

        public double PrecioUnitario { get; set; }

        [ForeignKey(("Vendedores"))]

        public int? FkVendedor { get; set; }

        public Vendedor Vendedores { get; set; }
    }
}
