using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProyecto.Entities;

namespace TestProyecto.Services
{
    public class CrudProducto
    {
        public void CreateProducto (Producto request)
        {
			try
			{
				if (request != null)
				{
					
				}
			}
			catch (Exception ex)
			{

				throw new Exception ("Error: "+ex.Message);
			}
        }

    }
}
