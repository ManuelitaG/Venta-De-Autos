using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class pedidoDTO
  {
    public PedidoCliente pedido { get; set; }
    public List<DetallePedidoCliente> detalles { get; set; }
  }
}