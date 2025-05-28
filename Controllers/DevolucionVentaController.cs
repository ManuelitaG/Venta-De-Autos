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
    [RoutePrefix("api/DevolucionVenta")]
    public class DevolucionVentaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<DevolucionVenta> ConsultarTodos()
        {
            clsDevolucionVenta clsdevolucionVenta = new clsDevolucionVenta();
            return clsdevolucionVenta.ConsultarTodos();
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] DevolucionVenta devolucionVenta)
        {
            clsDevolucionVenta clsdevolucionVenta = new clsDevolucionVenta();
            clsdevolucionVenta.devolucionVenta = devolucionVenta;
            return clsdevolucionVenta.Insertar();
        }

    }
}