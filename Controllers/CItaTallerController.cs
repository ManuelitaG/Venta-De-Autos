using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VentaAutos.Clases;
using VentaAutos.Models;

namespace VentaAutos.Controllers
{
    [RoutePrefix("api/CitaTaller")]
    public class CItaTallerController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<CitaTaller> ConsultarTodos()
        {
            clsCitaTaller clsCitaTaller = new clsCitaTaller();
            return clsCitaTaller.ConsultarTodos();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] CitaTaller citaTaller)
        {
            clsCitaTaller clscitaTaller = new clsCitaTaller();
            clscitaTaller.citaTaller = citaTaller;
         
            return clscitaTaller.Insertar();
        }
    }
}