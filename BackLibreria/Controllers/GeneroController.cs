using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE;
using BLL;

namespace BackLibreria.Controllers
{
    [RoutePrefix("libreria/Genero")]
    public class GeneroController : ApiController
    {

        [HttpGet]
        [Route("obtener")]
        public IHttpActionResult Get()
        {
            GestorGenero genero = new GestorGenero();
            return Ok( genero.GetAll());
        }

    }
}
