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
    [RoutePrefix("api/NotaCredito")]
    public class NotaCreditoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<NotaCredito> ConsultarTodos()
        {
            clsNotaCredito clsNotaCredito = new clsNotaCredito();
            return clsNotaCredito.ConsultarTodos();
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] NotaCredito notaCredito)
        {
            clsNotaCredito clsNotaCredito = new clsNotaCredito();
            clsNotaCredito.notaCredito = notaCredito;
            return clsNotaCredito.Insertar();
        }
    }
}