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
  [RoutePrefix("api/Cliente")]
  public class ClienteController : ApiController
  {
    [HttpGet]
    [Route("ConsultarTodos")]
    public List<Cliente> ConsultarTodos()
    {
      clsCliente clientes = new clsCliente();
      return clientes.ConsultarTodos();
    }

    [HttpPost]
    [Route("Registrar")]
    public string Registrar([FromBody] Cliente cliente)
    {
      clsCliente clientes = new clsCliente();
      clientes.cliente = cliente;

      return clientes.Registrar();
    }
  }
} 