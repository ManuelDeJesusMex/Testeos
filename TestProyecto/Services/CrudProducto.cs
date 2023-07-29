using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestProyecto.Context;
using TestProyecto.Entities;

namespace TestProyecto.Services
{
    public class CrudProducto
    {
        public void CreateProducto (Producto request, int IDSA)
        {
			//try
			//{

				if (request != null)
				{
				using (var _context = new ApplicationDbContext()) {


					
					Vendedor FindVendedor = _context.Vendedores.Find(IDSA);

						if (FindVendedor.PkVendedor == IDSA)
						{
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
                        } else if (FindVendedor.PkVendedor != IDSA)
						{
							MessageBox.Show("No se encontró el SA");
						}
						

						

				}
			}
			//}
			//catch (Exception ex)
			//{

			//	throw new Exception ("Error: "+ex.Message);
			//}
        }
		public void UpdateProducto (Producto request)
		{
			//try
			//{
				using (var _context = new ApplicationDbContext())
				{
					//Producto productoc = _context.Productos.Find(request.PkProducto);
					_context.Entry(request).State = EntityState.Modified;
					_context.SaveChanges();
					
				}
			//}
			//catch (Exception ex)
		//	{

				//throw new Exception("Error: "+ex.Message);
			//}
		}
		public List<Producto> GetProductos ()
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					List<Producto> Productos = new List<Producto>();
					Productos = _context.Productos.Include(x => x.Sabores).Include(y => y.Tamaños).Include(e => e.Lotes).Include(o => o.Vendedores).ToList();
					

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
		public void DeleteProducto (Producto request)
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					Producto DeleteP = _context.Productos.Find(request.PkProducto);

					if (DeleteP != null)
					{
						_context.Productos.Remove(DeleteP);
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
