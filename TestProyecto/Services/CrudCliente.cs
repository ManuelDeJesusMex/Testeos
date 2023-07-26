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
					if (updatec != null)
					{
						updatec.NombreCliente = request.NombreCliente;
						updatec.ApellidoCliente = request.ApellidoCliente;
						updatec.CorreoCliente = request.CorreoCliente;
						updatec.PasswordCliente = request.PasswordCliente;
						updatec.SaldoCliente = request.SaldoCliente;
						//	updatec.FkRol = request.FkRol;

						_context.Clientes.Update(updatec);
						_context.SaveChanges();
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
    }
}
