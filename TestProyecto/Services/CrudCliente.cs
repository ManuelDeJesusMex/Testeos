﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProyecto.Context;
using TestProyecto.Entities;

namespace TestProyecto.Services
{
    public class CrudCliente
    {
        public void CreateCliente (Cliente request) //Función para que cliente se registre y SA lo agregue
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

		
		public void UpdateCliente (Cliente requestUpdate) //Cliente y SA actualizarán cliente
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					_context.Entry(requestUpdate).State = EntityState.Modified;
					_context.SaveChanges();
				}
			}
			catch (Exception ex)
			{

				throw new Exception("Error: "+ ex.Message);
		}
		}

		public bool DeleteCliente (int ID) //SA lo podrá eliminar
		{
			try
			{
				using (var _context = new ApplicationDbContext ())
				{
					Cliente DeleteC = _context.Clientes.Find(ID);

					if (DeleteC != null)
					{
						_context.Clientes.Remove(DeleteC);
						_context.SaveChanges();
						return true;
					} else
					{
						return false;
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
