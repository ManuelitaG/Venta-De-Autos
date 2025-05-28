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
    [RoutePrefix("Reclamo/Garantia")]
    public class ReclamoGarantiaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<ReclamoGarantia> ConsultarTodos()
        {
            clsReclamoGarantia clsreclamoGarantia = new clsReclamoGarantia();
            return clsreclamoGarantia.ConsultarTodos();
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ReclamoGarantia reclamoGarantia)
        {
            clsReclamoGarantia clsreclamoGarantia = new clsReclamoGarantia();
            clsreclamoGarantia.reclamoGarantia = reclamoGarantia;
            return clsreclamoGarantia.Insertar();
        }

    }
}