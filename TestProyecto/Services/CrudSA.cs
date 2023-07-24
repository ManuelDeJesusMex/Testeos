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
        public List<Rol> GetRoles ()
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

				throw new Exception ("Error: "+ex.Message);
			}
        }


    }
}
