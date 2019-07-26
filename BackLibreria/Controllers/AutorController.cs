using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BE.EntidadesVistas;

namespace BackLibreria.Controllers
{
    [RoutePrefix("libreria/Autor")]
    public class AutorController : ApiController
    {


        [HttpGet]
        [Route("obtener")]


        public IHttpActionResult Get()
        {
            GestorAutor gestorAutor = new GestorAutor();
            return Ok(gestorAutor.GetAll());
        }
    }
}
