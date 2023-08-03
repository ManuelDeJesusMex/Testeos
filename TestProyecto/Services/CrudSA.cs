using Microsoft.EntityFrameworkCore;
using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
           // try
          //  {
                using (var _context = new ApplicationDbContext())
                {
                    SuperAdmin sau = _context.SuperAdministradores.Find(request.PkSuperAdmin);
                    Cliente NuevoCliente = new Cliente();
                    Vendedor NuevoVendedor = new Vendedor();

                    if (sau != null)
                    {
                        if (request.FkRol == 1)
                        {
                            NuevoCliente.NombreCliente = request.NombreSuperAdmin;
                            NuevoCliente.ApellidoCliente = request.ApellidoSuperAdmin;
                            NuevoCliente.CorreoCliente = request.CorreoSuperAdmin;
                            NuevoCliente.PasswordCliente = request.ContraseñaSuperAdmin;
                            NuevoCliente.SaldoCliente = 0;
                        NuevoCliente.FkRol = request.FkRol;

                            _context.Clientes.Add(NuevoCliente);
                            _context.SuperAdministradores.Remove(sau);
                            _context.SaveChanges();
                        }
                        else if (request.FkRol == 2)
                        {
                           NuevoVendedor.NombreVendedor = request.NombreSuperAdmin;
                            NuevoVendedor.ApellidoVendedor = request.ApellidoSuperAdmin;
                            NuevoVendedor.CorreoV = request.CorreoSuperAdmin;
                            NuevoVendedor.ContraseñaVendedor = request.ContraseñaSuperAdmin;
                            NuevoVendedor.FkRol = request.FkRol;

                            _context.Vendedores.Add(NuevoVendedor);
                            _context.SuperAdministradores.Remove(sau);
                            _context.SaveChanges();
                        }
                        else if (request.FkRol == 3)
                        {
                            sau.NombreSuperAdmin = request.NombreSuperAdmin;
                            sau.ApellidoSuperAdmin = request.ApellidoSuperAdmin;
                            sau.CorreoSuperAdmin = request.CorreoSuperAdmin;
                            sau.ContraseñaSuperAdmin = request.ContraseñaSuperAdmin;
                            sau.FkRol = request.FkRol;

                            _context.SuperAdministradores.Update(sau);
                            _context.SaveChanges();
                        } else
                    {
                        sau.NombreSuperAdmin = request.NombreSuperAdmin;
                        sau.ApellidoSuperAdmin = request.ApellidoSuperAdmin;
                        sau.CorreoSuperAdmin = request.CorreoSuperAdmin;
                        sau.ContraseñaSuperAdmin = request.ContraseñaSuperAdmin;
                        sau.FkRol = request.FkRol;

                        _context.SuperAdministradores.Update(sau);
                        _context.SaveChanges();
                    }
                        
                    } else
                    {
                        MessageBox.Show("Los datos fueron nulos");
                    }
                }
            //}
           // catch (Exception ex)
            //{

            //    throw new Exception ("Error: "+ex.Message);
            //}
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
        public void CreateRol (Rol request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Rol rolc = new Rol();

                        rolc.RolName = request.RolName;

                        _context.Roles.Add(rolc);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception ("Error: "+ex.Message);
            }
        }
        public void UpdateRol (Rol request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Rol rolu = _context.Roles.Find(request.PkRol);

                        if (rolu != null)
                        {
                            rolu.RolName = request.RolName;

                            _context.Roles.Update(rolu);
                            _context.SaveChanges();
                        } else
                        {
                            MessageBox.Show("No se encontró el rol");
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception ("Error: "+ex.Message);
            }
        }
        public void DeleteRol (Rol request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Rol rold = _context.Roles.Find (request.PkRol);

                        if (rold != null)
                        {
                            _context.Roles.Remove(rold);
                            _context.SaveChanges();
                        } else
                        {
                            MessageBox.Show("No se encontró el rol");
                        }

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
