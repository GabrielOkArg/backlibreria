using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.EntidadesVistas;
using DAL.Mappers;

namespace BLL
{
    public class GestorAutor
    {


        public List<AutorVista> GetAll()
        {
            MapperAutor mapperAutor = new MapperAutor();
            return mapperAutor.ObtenerAutores();
        }

        public static AutorVista GetByName(string name)
        {
            MapperAutor mapperAutor = new MapperAutor();
            return mapperAutor.GetByName(name);
        }
    }
}
