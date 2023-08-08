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
                            NewProduct.FkTamano = request.FkTamano;

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
					Productos = _context.Productos.Include(x => x.Sabores).Include(y => y.Tamanos).Include(e => e.Lotes).Include(o => o.Vendedores).ToList();
					

                    return Productos;
				}
			}
			catch (Exception ex )
			{

				throw new Exception("Error: "+ex.Message);
			}
		}
		public List<Tamano> GetTamaños ()
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					List<Tamano> tamaños = _context.Tamanos.ToList();
					

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
		public void CreateSabor (Sabor request)
		{
			try
			{
				using (var  _context = new ApplicationDbContext()) {
					if (request != null)
					{
						Sabor Nuevo = new Sabor();
						Nuevo.NameSabor = request.NameSabor;

						_context.Sabores.Add(request);
						_context.SaveChanges();

					}
				}
			}
			catch (Exception ex)
			{

				throw new Exception ("Error: "+ex.Message);
			}
		}
		public void CreateTamaño (Tamano request)
		{
            try
            {
                using (var _context = new ApplicationDbContext())
                {
					if (request != null)
					{
						Tamano nuevo = new Tamano();
						nuevo.TamanoP = request.TamanoP;

						_context.Tamanos.Add(nuevo);
						_context.SaveChanges();
					}
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
		public void CreateLote (Lote request)
		{
            try
            {
                using (var _context = new ApplicationDbContext())
                {
					if (request != null)
					{
						Lote nuevo = new Lote();
						nuevo.NomLote = request.NomLote;

						_context.Lotes.Add(nuevo);
						_context.SaveChanges();
					}
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
		public void UpdateTamano (string NombreP, int IDP)
		{
			try
			{
				using (var _context = new ApplicationDbContext())
				{
					Tamano tamanoc = _context.Tamanos.Find(IDP);

					if (tamanoc != null)
					{
						tamanoc.TamanoP = NombreP;
						_context.Tamanos.Update(tamanoc);
						_context.SaveChanges ();
					}
				}
			}
			catch (Exception ex)
			{

				throw new Exception ("Error: "+ex.Message);
			}
		}
		public void UpdateSabor (string NombreS, int IDS)
		{
            try
            {
                using (var _context = new ApplicationDbContext())
                {
					Sabor saborc = _context.Sabores.Find(IDS);

					if (saborc != null)
					{
						saborc.NameSabor = NombreS;
						_context.Sabores.Update(saborc);
						_context.SaveChanges ();
					}
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
		public void UpdateLote (int NomLote, int IDL)
		{
            try
            {
                using (var _context = new ApplicationDbContext())
                {
					Lote lotec = _context.Lotes.Find(IDL);
					if (lotec != null)
					{
						lotec.NomLote = NomLote;
						_context.Lotes.Update(lotec); _context.SaveChanges ();
					}
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
		public List<DetalleVenta> GetDetalleVentas () {
			try
			{
				using (var _context = new ApplicationDbContext())
				{

					List<DetalleVenta> lista = new List<DetalleVenta> ();

					lista = _context.detalleVentas.Include(x => x.Venta).Include(y => y.Producto).ToList();



					return lista;
				}
			}
			catch (Exception ex)
			{

				throw new Exception ("Error: "+ex.Message);
			}
		}

		
		
    }
}
