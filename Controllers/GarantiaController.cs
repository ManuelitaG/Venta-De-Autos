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
    [RoutePrefix("api/Garantia")]
    public class GarantiaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Garantia> ConsultarTodos()
        {
            clsGarantia clsgarantia = new clsGarantia();
            return clsgarantia.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarTodosXPlaca")]
        public Garantia ConsultarTodosXPlaca(int placa)
        {
            clsGarantia clsgarantia = new clsGarantia();
            return clsgarantia.ConsultarTodosXPlaca(placa);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Garantia garantia)
        {
            clsGarantia clsgarantia = new clsGarantia();
            clsgarantia.garantia = garantia;

            return clsgarantia.Insertar();
        }

    }
}