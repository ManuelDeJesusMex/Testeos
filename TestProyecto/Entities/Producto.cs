﻿using System;
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
        public double PrecioUnitario { get; set; }

        [ForeignKey(("Vendedores"))]

        public int? FkVendedor { get; set; } //Se tendrá que ingrsar el foreign key del vendedor/admin quien ingreso la bebida

        public Vendedor Vendedores { get; set; }

        [ForeignKey(("Lotes"))]

        public int? FkLote { get; set; }

        public Lote Lotes { get; set; }

        [ForeignKey(("Sabores"))]

        public int? FkSabor { get; set; }

        public Sabor Sabores { get; set; }

        [ForeignKey(("Tamaños"))]

        public int FkTamaño { get; set; }

        public Tamaño Tamaños { get; set; }

        

        


    }
}
