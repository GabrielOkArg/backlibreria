using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.EntidadesVistas;
using DAL.Mappers;


namespace BLL
{
    public class GestorLibro
    {

        public List<BE.EntidadesVistas.LibroVista> ListadoLibros()
        {
            DAL.Mappers.MapperLibro mapperLibro = new DAL.Mappers.MapperLibro();
            return mapperLibro.libroVistas();
            //byte[] x = Convert.FromBase64String("YWFjY2lvbjIwMTlz");
            //string recuperado = System.Text.ASCIIEncoding.ASCII.GetString(x);
        }

        public List<BE.EntidadesVistas.LibroVista> ListadoLibrosDetalle(string titulo)
        {
            DAL.Mappers.MapperLibro mapperLibro = new DAL.Mappers.MapperLibro();
            return mapperLibro.libroVistasDetalle(titulo);
        }

        public List<BE.EntidadesVistas.LibroVista> ListadoLibros(string titulo)
        {
            DAL.Mappers.MapperLibro mapperLibro = new DAL.Mappers.MapperLibro();
            return mapperLibro.libroVistas(titulo);
        }

        public bool Createbook(LibroVista obj)
        {
            try
            {
                MapperLibro mapperLibro = new MapperLibro();
                obj.autor = Convert.ToString( GestorAutor.GetByName(obj.autor).id);
                obj.genero = Convert.ToString(GestorGenero.GetByName(obj.genero).id);
                mapperLibro.NewBook(obj);
                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }

        public bool DeleteBook(LibroVista obj)
        {
            try
            {
                MapperLibro mapperLibro = new MapperLibro();
                mapperLibro.DeleteBook(obj);
                return true;
            }
            catch (Exception e )
            {

                throw;
            }
        }

    }
}
