using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.EntidadesVistas;

namespace DAL.Mappers
{
    public class MapperGenero
    {



        public static List<BE.EntidadesVistas.GeneroVista> generoVistas()
        {
            try
            {
                liberiaDBEntities liberiaDBEntities = new liberiaDBEntities();
                var query = (from e in liberiaDBEntities.genero select e);
                List<BE.EntidadesVistas.GeneroVista> Listado = new List<BE.EntidadesVistas.GeneroVista>(); 
                foreach (genero item in query)
                {
                    BE.EntidadesVistas.GeneroVista vista = new BE.EntidadesVistas.GeneroVista();
                    vista.nombre = item.nombreg;
                    Listado.Add(vista);
                }
                return Listado;
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                throw;
            }
        }

        public GeneroVista GetByName(string name)
        {
            try
            {
                AutorVista AutorAuxiliar = new AutorVista();
                liberiaDBEntities liberiaDBEntities = new liberiaDBEntities();
                var query = (from e in liberiaDBEntities.genero where e.nombreg == name select e).FirstOrDefault();
                GeneroVista vista = new GeneroVista();
                vista.nombre = query.nombreg;
                vista.id = Convert.ToString( query.id);
                return vista;
            }
            catch (Exception e)
            {
                string x = e.Message;
                return null;
            }
        }


    }
}
