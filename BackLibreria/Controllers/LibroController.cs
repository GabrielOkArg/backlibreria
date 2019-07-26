using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using BE.EntidadesVistas;
using BLL;


namespace BackLibreria.Controllers 
{
    [RoutePrefix("libreria/libros")]

    
    public class LibroController : ApiController
    {

       
        [HttpGet]
        [Route("obtener")]
        
        public IHttpActionResult Get()
        {
            GestorLibro libro = new GestorLibro();
            // return "Te invito a pelear Prro";
            if (libro == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(libro.ListadoLibros());
            }
           
        }

        [HttpGet]
        [Route("getbytitulo/{titulo}")]

        public IHttpActionResult GetName(string titulo)
        {
            GestorLibro libro = new GestorLibro();

           
            if (libro == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(libro.ListadoLibros(titulo));
            }

        }

        [HttpGet]
        [Route("getdetalle/{titulo}")]

        public IHttpActionResult GetDetalle(string titulo)
        {
            GestorLibro libro = new GestorLibro();


            if (libro == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(libro.ListadoLibrosDetalle(titulo));
            }

        }

        [HttpPost]
        [Route("create")]
        public  IHttpActionResult Post([FromBody] LibroVista libroVista)
        {
            try
            {
                GestorLibro gestorLibro = new GestorLibro();
                gestorLibro.Createbook(libroVista);

                return Ok();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }// fin crear libro


        [HttpPut]
        [Route("delete")]

        public IHttpActionResult Put([FromBody] LibroVista libroVista)
        {
            try
            {
                GestorLibro gestorLibro = new GestorLibro();
                gestorLibro.DeleteBook(libroVista);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError();
            }
        }


    }
}
