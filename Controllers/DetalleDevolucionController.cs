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
    [RoutePrefix("api/DetalleDevolucion")]
    public class DetalleDevolucionController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<DetalleDevolucion> ConsultarTodos()
        {
            clsDetalleDevolucion clsDetalleDevolucion = new clsDetalleDevolucion();
            return clsDetalleDevolucion.ConsultarTodos();
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] DetalleDevolucion detalleDevolucion)
        {
            clsDetalleDevolucion clsdetalleDevolucion = new clsDetalleDevolucion();
            clsdetalleDevolucion.detalleDevolucion = detalleDevolucion;
            return clsdetalleDevolucion.Insertar();
        }

    }
}