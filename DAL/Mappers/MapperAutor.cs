using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.EntidadesVistas;

namespace DAL.Mappers
{
    public class MapperAutor
    {



        public List<AutorVista> ObtenerAutores()
        {
            List<AutorVista> listado = new List<AutorVista>();
            try
            {
                liberiaDBEntities liberiaDBEntities = new liberiaDBEntities();
                var query = (from e in liberiaDBEntities.autor select e).ToList();
                for (int i = 0; i < query.Count; i++)
                {
                    AutorVista autor = new AutorVista();
                    autor.nombre = query[i].nombre;
                    listado.Add(autor);
                }
                return listado;
            }
            catch (Exception e)
            {
                string x = e.Message;
                return null;
            }
        }

        public AutorVista GetByName(string name)
        {
            try
            {
                AutorVista AutorAuxiliar = new AutorVista();
                liberiaDBEntities liberiaDBEntities = new liberiaDBEntities();
                var query = (from e in liberiaDBEntities.autor where e.nombre == name select e ).FirstOrDefault();
                AutorVista vista = new AutorVista();
                vista.nombre = query.nombre;
                vista.id = query.id;
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
