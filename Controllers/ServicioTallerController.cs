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
    [RoutePrefix("api/ServicioTaller")]
    public class ServicioTallerController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<ServicioTaller> ConsultarTodos()
        {
            clsServicioTaller clsServicioTaller = new clsServicioTaller();
            return clsServicioTaller.ConsultarTodos();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ServicioTaller servicioTaller)
        {
            clsServicioTaller clsservicioTaller = new clsServicioTaller();
            clsservicioTaller.servicioTaller = servicioTaller;

            return clsservicioTaller.Insertar();
        }
    }
}