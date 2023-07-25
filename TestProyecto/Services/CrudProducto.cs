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
    public class CrudProducto
    {
        public void CreateProducto (Producto request)
        {
			try
			{

				if (request != null)
				{
					using (var _context = new ApplicationDbContext()) {
						Producto NewProduct = new Producto();

						NewProduct.Nombre = request.Nombre;
						NewProduct.Cantidad = request.Cantidad;
						NewProduct.PrecioUnitario = request.PrecioUnitario;
						NewProduct.FkLote = request.FkLote;
						NewProduct.FkVendedor = request.FkVendedor;
						NewProduct.FkSabor = request.FkSabor;
						NewProduct.FkTamaño = request.FkTamaño;

						_context.Productos.Add(NewProduct);
						_context.SaveChanges();

				}
			}
			}
			catch (Exception ex)
			{

				throw new Exception ("Error: "+ex.Message);
			}
        }
		public List<Producto> GetProductos ()
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					List<Producto> Productos = new List<Producto>();
					Productos = _context.Productos.ToList();

					return Productos;
				}
			}
			catch (Exception ex )
			{

				throw new Exception("Error: "+ex.Message);
			}
		}
		public List<Tamaño> GetTamaños ()
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					List<Tamaño> tamaños = _context.Tamaños.ToList();
					

					return tamaños;
				}
			}
			catch (Exception ex)
			{

				throw new Exception("Error: "+ex.Message);
			}
		}

		public List<Sabor> GetSabores ()
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					List<Sabor> Sabores = _context.Sabores.ToList();

					return Sabores;
				}
			}
			catch (Exception ex)
			{

				throw new Exception ("Error: "+ex.Message);
			}
		}
        public List<Lote> GetLotes()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Lote> LotesB = _context.Lotes.ToList();

                    return LotesB;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}