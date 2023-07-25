using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProyecto.Context;
using TestProyecto.Entities;

namespace TestProyecto.Services
{
    public class CrudVendedor
    {

        public void CreateVendedor(Vendedor request) //Función para que cliente se registre y SA lo agregue
        {
            try
            {
            if (request != null)
            {

                using (var _context = new ApplicationDbContext())
                {
                    Vendedor NewVendedor = new Vendedor();



                    NewVendedor.NombreVendedor = request.NombreVendedor;
                    NewVendedor.ApellidoVendedor = request.ApellidoVendedor;
                    NewVendedor.CorreoV = NewVendedor.CorreoV;
                    NewVendedor.ContraseñaVendedor = NewVendedor.ContraseñaVendedor;                   
                    NewVendedor.FkRol = request.FkRol;

                    //Detalle, saldo se està ingresando como null aunque le especifiquemos el valor

                    _context.Vendedores.Add(request);
                    _context.SaveChanges();
                }
            }
            }
            catch (Exception ex)
            {

            	throw new Exception ("Error: "+ex.Message);
            }
        }

    }
}
