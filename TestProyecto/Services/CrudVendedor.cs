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

                throw new Exception("Error: " + ex.Message);
            }
        }
        public void DeleteVendedor (Vendedor request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Vendedor deleteV = _context.Vendedores.Find(request.PkVendedor);

                    if (deleteV != null)
                    {
                        _context.Vendedores.Remove(deleteV);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception ("Error: "+ex.Message);
            }
        }
       public void UpdateCliente (Vendedor request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Vendedor vendeMod = _context.Vendedores.Find(request.PkVendedor);
                    Cliente clientemod = new Cliente();
                    SuperAdmin samod = new SuperAdmin();

                    if (request.FkRol == 1)
                    {
                        clientemod.NombreCliente = request.NombreVendedor;
                        clientemod.ApellidoCliente = request.ApellidoVendedor;
                        clientemod.CorreoCliente = request.CorreoV;
                        clientemod.PasswordCliente = request.ContraseñaVendedor;
                        clientemod.SaldoCliente = 0; //Se le asigna 0 pues vendedor no tiene saldo
                        clientemod.FkRol = request.FkRol;

                        _context.Clientes.Add(clientemod);
                        _context.Vendedores.Remove(vendeMod);
                        _context.SaveChanges();

                    } else if (request.FkRol == 2)
                    {
                        vendeMod.NombreVendedor = request.NombreVendedor;
                        vendeMod.ApellidoVendedor = request.ApellidoVendedor;
                        vendeMod.ContraseñaVendedor = request.ContraseñaVendedor;
                        vendeMod.CorreoV = request.CorreoV;
                        vendeMod.FkRol = request.FkRol;

                        _context.Vendedores.Update(vendeMod);
                        _context.SaveChanges();

                    } else if (request.FkRol == 3)
                    {
                        samod.NombreSuperAdmin = request.NombreVendedor;
                        samod.ApellidoSuperAdmin = request.ApellidoVendedor;
                        samod.CorreoSuperAdmin = request.CorreoV;
                        samod.ContraseñaSuperAdmin = request.ContraseñaVendedor;
                        samod.FkRol = request.FkRol;

                        _context.SuperAdministradores.Add(samod);
                        _context.Vendedores.Remove(vendeMod);
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
