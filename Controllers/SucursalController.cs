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
    [RoutePrefix("api/Sucursal")]
    public class SucursalController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Sucursal> ConsultarTodos()
        {
            clsSucursal sucursales = new clsSucursal();
            return sucursales.ConsultarTodos();
        }

        [HttpPost]
        [Route("Registrar")]
        public string Registrar([FromBody] Sucursal sucursal)
        {
            clsSucursal sucursales = new clsSucursal();
            sucursales.sucursal = sucursal;

            return sucursales.Insertar();
        }
    }
}