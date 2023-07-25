using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProyecto.Context;
using TestProyecto.Entities;

namespace TestProyecto.Services
{
    public class CrudSA
    {
        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = _context.Roles.ToList();

                    return roles;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }

        public List<Cliente> GetClientes() //Lectura de clientes valido solo para SA
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Cliente> Clientes = new List<Cliente>();

                    Clientes = _context.Clientes.Include(x => x.Roles).ToList();
                    return Clientes;

                }


            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
        public List<Vendedor> GetVendedores ()
        {
            try
            {
                using (var _context = new ApplicationDbContext ())
                {
                    List<Vendedor> vendedores = new List<Vendedor>();
                    vendedores = _context.Vendedores.Include(x => x.Roles).ToList();

                    return vendedores;
                }
            }
            catch (Exception ex)

            {

                throw new Exception ("Error: "+ex.Message);
            }
        }
    }
}
