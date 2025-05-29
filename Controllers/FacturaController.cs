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
  [RoutePrefix("api/Factura")]
  public class FacturaController : ApiController
  {
    [HttpPost]
    [Route("GenerarFactura")]
    public FacturaVenta GenerarFactura(int numeroPedido, string documentoEmpleado)
    {
      clsFactura facturas = new clsFactura();

      return facturas.GenerarFacturaDesdePedido(numeroPedido, documentoEmpleado);
    }

    [HttpGet]
    [Route("ConsultarComprasCliente/{documento}")]
    public List<object> ConsultarComprasCliente(string documento)
    {
      clsFactura facturas = new clsFactura();
      return facturas.ObtenerHistorialCompras(documento);
    }
  }
}