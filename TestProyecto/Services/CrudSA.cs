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

        public void CreateAdmin (SuperAdmin request)
        {
            try
            {
                if (request != null)
                {
                    SuperAdmin NewSuperAdmin = new SuperAdmin();
                    using (var _context = new ApplicationDbContext ())
                    {
                        NewSuperAdmin.NombreSuperAdmin = request.NombreSuperAdmin;
                        NewSuperAdmin.ApellidoSuperAdmin = request.ApellidoSuperAdmin;
                        NewSuperAdmin.CorreoSuperAdmin = request.CorreoSuperAdmin;
                        NewSuperAdmin.ContraseñaSuperAdmin = request.ContraseñaSuperAdmin;
                        NewSuperAdmin.FkRol = request.FkRol;

                        _context.SuperAdministradores.Add(NewSuperAdmin);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
        public void UpdateSA (SuperAdmin request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    SuperAdmin sau = _context.SuperAdministradores.Find(request.PkSuperAdmin);

                    if (sau != null)
                    {
                        sau.NombreSuperAdmin = request.NombreSuperAdmin;
                        sau.ApellidoSuperAdmin = request.ApellidoSuperAdmin;
                        sau.CorreoSuperAdmin = request.CorreoSuperAdmin;
                        sau.ContraseñaSuperAdmin = request.ContraseñaSuperAdmin;
                        // sau.FkRol = request.FkrRol;

                        _context.SuperAdministradores.Update(sau);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception ("Error: "+ex.Message);
            }
        }

        public void DeleteSA (SuperAdmin request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    SuperAdmin deleteSA = _context.SuperAdministradores.Find(request.PkSuperAdmin);
                    if (deleteSA != null)
                    {
                        _context.SuperAdministradores.Remove(deleteSA);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception ("Error: "+ex.Message);
            }
        }
        public void UpdateVendedores (Vendedor request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Vendedor vendedoru = _context.Vendedores.Find(request.PkVendedor);

                    if (vendedoru != null)
                    {
                        vendedoru.NombreVendedor = request.NombreVendedor;
                        vendedoru.ApellidoVendedor = request.ApellidoVendedor;
                        vendedoru.CorreoV = request.CorreoV;
                        vendedoru.ContraseñaVendedor = request.ContraseñaVendedor;
                        // vendedoru.FkRol = request.FkRol;

                        _context.Vendedores.Update(vendedoru);
                        _context.SaveChanges();
                    }
                }

                
            }
            catch (Exception ex)
            {

                throw new Exception ("Error: " + ex.Message);
            }
        }
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
        //
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
        public List<SuperAdmin> GetSuperAdmins ()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<SuperAdmin> superAdmins = new List<SuperAdmin>();
                    superAdmins = _context.SuperAdministradores.Include(x => x.Roles).ToList();

                    return superAdmins;
                }
            }
            catch (Exception ex)
            {

                throw new Exception ("Error: "+ex.Message);
            }
        }
        public SuperAdmin LogSA (string nombre, string password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var sa = _context.SuperAdministradores.Include(y => y.Roles).FirstOrDefault(x => x.NombreSuperAdmin == nombre && x.ContraseñaSuperAdmin == password);
                    return sa;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: "+ex.Message);
            }
        }
    }
}
