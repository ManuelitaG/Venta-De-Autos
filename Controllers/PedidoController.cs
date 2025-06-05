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
        public string Registrar([FromBody] pedidoDTO data)
        {
            clsPedido pedidos = new clsPedido();
            pedidos.pedido = data.pedido;
            pedidos.detalles = data.detalles;

            return pedidos.Insertar();
        }

        [HttpGet]
        [Route("ConsultarPedidosCliente/{documento}")]
        public List<object> ConsultarPedidosCliente(string documento)
        {
            clsPedido pedido = new clsPedido();
            return pedido.ConsultarXCliente(documento);
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<object> ConsultarTodos()
        {
            clsPedido pedido = new clsPedido();
            return pedido.ConsultarTodos();
        }


        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PedidoCliente pedido)
        {
            clsPedido pedidos = new clsPedido();
            return pedidos.Actualizar(pedido);
        }
    }
}
