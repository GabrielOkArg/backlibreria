using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.EntidadesVistas;
using DAL.Mappers;


namespace BLL
{
    public class GestorGenero
    {


        public List<BE.EntidadesVistas.GeneroVista> GetAll()
        {
            return DAL.Mappers.MapperGenero.generoVistas();
        }

        public static GeneroVista GetByName(string name)
        {
            MapperGenero mapperGenero = new MapperGenero();
            return mapperGenero.GetByName(name);
        }

    }
}
