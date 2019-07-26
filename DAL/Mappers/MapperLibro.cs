using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.EntidadesVistas;

namespace DAL.Mappers
{
    public class MapperLibro
    {



        public List<BE.EntidadesVistas.LibroVista> libroVistas()
        {
            List<BE.EntidadesVistas.LibroVista> listado = new List<BE.EntidadesVistas.LibroVista>();
            try
            {
                liberiaDBEntities liberiaDBEntities = new liberiaDBEntities();
                var QUERY = (from El in (from e in liberiaDBEntities.libro
                                                join g in liberiaDBEntities.genero
                                                 on e.genero equals g.id
                                                select new { e.titulo, e.año, e.portada, g.nombreg, e.autor })
                                    join a in liberiaDBEntities.autor on El.autor equals a.id
                                    select new { El.titulo, El.portada, El.año, El.nombreg, a.nombre }).ToList();
                for (int i = 0; i < QUERY.Count; i++)
                {
                    BE.EntidadesVistas.LibroVista libro = new BE.EntidadesVistas.LibroVista();
                    libro.titulo = QUERY[i].titulo;
                    libro.portada = QUERY[i].portada;
                    libro.año = Convert.ToString( QUERY[i].año);
                    libro.genero = QUERY[i].nombreg;
                    libro.autor = QUERY[i].nombre;
                    listado.Add(libro);

                }
               
             
                return listado;
            }
            catch (Exception e)
            {
                string x = e.Message;
                return null;
                throw;
            }
        }


        public List<BE.EntidadesVistas.LibroVista> libroVistas(string titulo)
        {
            List<BE.EntidadesVistas.LibroVista> listado = new List<BE.EntidadesVistas.LibroVista>();
            try
            {
                liberiaDBEntities liberiaDBEntities = new liberiaDBEntities();
                var QUERY = (from El in (from e in liberiaDBEntities.libro
                                         join g in liberiaDBEntities.genero
                                          on e.genero equals g.id where e.titulo.Contains(titulo)
                                         select new { e.titulo, e.año, e.portada, g.nombreg, e.autor })
                             join a in liberiaDBEntities.autor on El.autor equals a.id
                             select new { El.titulo, El.portada, El.año, El.nombreg, a.nombre }).ToList();
                for (int i = 0; i < QUERY.Count; i++)
                {
                    BE.EntidadesVistas.LibroVista libro = new BE.EntidadesVistas.LibroVista();
                    libro.titulo = QUERY[i].titulo;
                    libro.portada = QUERY[i].portada;
                    libro.año = Convert.ToString(QUERY[i].año);
                    libro.genero = QUERY[i].nombreg;
                    libro.autor = QUERY[i].nombre;
                    listado.Add(libro);

                }


                return listado;
            }
            catch (Exception e)
            {
                string x = e.Message;
                return null;
                throw;
            }
        }// fin no se que

        public bool NewBook(LibroVista libroVista)
        {
            try
            {
                libro libro1 = new libro();
                libro1.titulo = libroVista.titulo;
                libro1.autor = Convert.ToInt32( libroVista.autor);
                libro1.año =Convert.ToInt32(libroVista.año);
                libro1.portada = libroVista.portada;
                libro1.genero = Convert.ToInt32(libroVista.genero);
                libro1.edicion = 1;
                liberiaDBEntities liberiaDBEntities = new liberiaDBEntities();
                liberiaDBEntities.libro.Add(libro1);
                liberiaDBEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string x = e.Message;
                throw;
            }
        }//fin alta de libro


        public bool DeleteBook(LibroVista libroVista)
        {
            try
            {
                liberiaDBEntities liberiaDBEntities = new liberiaDBEntities();
                var query = (from e in liberiaDBEntities.libro where e.titulo == libroVista.titulo select e).FirstOrDefault();
                liberiaDBEntities.libro.Remove(query);
                liberiaDBEntities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public List<BE.EntidadesVistas.LibroVista> libroVistasDetalle(string titulo)
        {
            List<BE.EntidadesVistas.LibroVista> listado = new List<BE.EntidadesVistas.LibroVista>();
            try
            {
                liberiaDBEntities liberiaDBEntities = new liberiaDBEntities();
                var QUERY = (from El in (from e in liberiaDBEntities.libro
                                         join g in liberiaDBEntities.genero
                                          on e.genero equals g.id
                                         where e.titulo == titulo
                                         select new { e.titulo, e.año, e.portada, g.nombreg, e.autor })
                             join a in liberiaDBEntities.autor on El.autor equals a.id
                             select new { El.titulo, El.portada, El.año, El.nombreg, a.nombre }).ToList();
                for (int i = 0; i < QUERY.Count; i++)
                {
                    BE.EntidadesVistas.LibroVista libro = new BE.EntidadesVistas.LibroVista();
                    libro.titulo = QUERY[i].titulo;
                    libro.portada = QUERY[i].portada;
                    libro.año = Convert.ToString(QUERY[i].año);
                    libro.genero = QUERY[i].nombreg;
                    libro.autor = QUERY[i].nombre;
                    listado.Add(libro);

                }


                return listado;
            }
            catch (Exception e)
            {
                string x = e.Message;
                return null;
                throw;
            }
        }// fin no se que
    }
}
