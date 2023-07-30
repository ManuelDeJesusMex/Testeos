using Microsoft.EntityFrameworkCore;
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
	public class CrudCliente
	{
		public void CreateCliente(Cliente request) //Función para que cliente se registre y SA lo agregue
		{
			//try
			//{
			if (request != null)
			{

				using (var _context = new ApplicationDbContext())
				{
					Cliente NewCliente = new Cliente();



					NewCliente.NombreCliente = request.NombreCliente;
					NewCliente.ApellidoCliente = request.ApellidoCliente;
					NewCliente.CorreoCliente = request.CorreoCliente;
					NewCliente.PasswordCliente = request.PasswordCliente;
					NewCliente.SaldoCliente = request.SaldoCliente;
					NewCliente.FkRol = request.FkRol;

					//Detalle, saldo se està ingresando como null aunque le especifiquemos el valor

					_context.Clientes.Add(request);
					_context.SaveChanges();
				}
			}
			//}
			//catch (Exception ex)
			//{

			//	throw new Exception ("Error: "+ex.Message);
			//}
		}





		public void UCliente(Cliente request)
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					Cliente updatec = _context.Clientes.Find(request.PkCliente);
					Vendedor vendedorN = new Vendedor();
					SuperAdmin admin = new SuperAdmin();

					if (request.FkRol == 1)
					{
                        if (updatec != null)
                        {
                            updatec.NombreCliente = request.NombreCliente;
                            updatec.ApellidoCliente = request.ApellidoCliente;
                            updatec.CorreoCliente = request.CorreoCliente;
                            updatec.PasswordCliente = request.PasswordCliente;
                            updatec.SaldoCliente = request.SaldoCliente;
                            updatec.FkRol = request.FkRol;

                            _context.Clientes.Update(updatec);
                            _context.SaveChanges();
                        }
						//FGd
                    }
					else if (request.FkRol == 2)
					{
                       if (updatec != null)
                        {
                            vendedorN.NombreVendedor = request.NombreCliente;
                            vendedorN.ApellidoVendedor = request.ApellidoCliente;
                            vendedorN.CorreoV = request.CorreoCliente;
                            vendedorN.ContraseñaVendedor = request.PasswordCliente;
                                                      

							vendedorN.FkRol = request.FkRol;


							_context.Vendedores.Add(vendedorN);
                           _context.Clientes.Remove(updatec);
							_context.SaveChanges();

                       }
                  } else if (request.FkRol == 3)
					{
						if (updatec != null)
						{
							admin.NombreSuperAdmin = request.NombreCliente;
							admin.ApellidoSuperAdmin = request.ApellidoCliente;
							admin.CorreoSuperAdmin = request.CorreoCliente;
							admin.ContraseñaSuperAdmin = request.PasswordCliente;
							admin.FkRol = request.FkRol;

							_context.SuperAdministradores.Add(admin);
							_context.Clientes.Remove(updatec);
							_context.SaveChanges();
						}
					} 
					
				}
			}
			catch (Exception ex)
			{

				throw new Exception("Error: " + ex.Message);
			}
		}

		
		
		public void DeleteCliente(Cliente request) //SA lo podrá eliminar
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					Cliente DeleteC = _context.Clientes.Find(request.PkCliente);

					if (DeleteC != null)
					{
						_context.Clientes.Remove(DeleteC);
						_context.SaveChanges();

					} else
					{
						MessageBox.Show("No se encontró");
					}
				}
			}
			catch (Exception ex)
			{

				throw new Exception("Error: " + ex.Message);
			}
		}

		public Cliente LoginC (string Nombre, string Password)
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					var cliente = _context.Clientes.Include(y => y.Roles).FirstOrDefault(x => x.NombreCliente == Nombre && x.PasswordCliente == Password);

					return cliente;
				}
			}
			catch (Exception ex)
			{

				throw new Exception("Error: "+ex.Message);
			}
		}
		public void Compra (int request, int Cantidad, int IDCliente)
		{
			//En la compra se harán 3 modificaciones, Al cliente con su saldo,
			//al producto con su cantidad y la creación de la venta junto al detalle de venta
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					Venta NuevaCompra = new Venta();
					DateTime FechadeCompr = DateTime.Now;


					Producto CompraP = _context.Productos.Find(request);
					Cliente ClienteCompra = _context.Clientes.Find(IDCliente);

					if (ClienteCompra != null)
					{
                        if (CompraP != null)
                        {
							if (Cantidad == CompraP.Cantidad || Cantidad <= CompraP.Cantidad)
							{
								double Subtotal = (Cantidad * CompraP.PrecioUnitario);
								double IVA = (Subtotal * .16);
								double total = Subtotal + IVA;

								if (ClienteCompra.SaldoCliente == total || ClienteCompra.SaldoCliente > total)
								{
									NuevaCompra.FechaCompra = FechadeCompr;
									NuevaCompra.FkCliente = ClienteCompra.PkCliente;

									double NuevoSaldo = ClienteCompra.SaldoCliente - total;
									int NuevaCantidad = CompraP.Cantidad - Cantidad;

									CompraP.Cantidad = NuevaCantidad;
									ClienteCompra.SaldoCliente = NuevoSaldo;

									_context.Ventas.Add(NuevaCompra);
									_context.Clientes.Update(ClienteCompra);
									_context.Productos.Update(CompraP);
									_context.SaveChanges();

									MessageBox.Show("Producot comprado");

								} else
								{
									MessageBox.Show("Saldo insuficiente");
								}
                            }
                            else 
                            {
                                MessageBox.Show("Te estás excediendo de la cantidad disponible");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto");
                        }
                    } else
					{
						MessageBox.Show("No existe el cliente o está mal escrito");
					}

					
				}
			}
			catch (Exception ex)
			{

				throw new Exception("Error: " + ex.Message);
			}
		}
    }
}
