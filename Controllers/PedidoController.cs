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
  [RoutePrefix("api/Pedido")]
  public class PedidoController : ApiController
  {
    [HttpPost]
    [Route("Insertar")]
    public string Registrar(PedidoCliente pedido, List<DetallePedidoCliente> detalles)
    {
      clsPedido pedidos = new clsPedido();
      pedidos.pedido = pedido;
      pedidos.detalles = detalles;

      return pedidos.Insertar();
    }
  }
}