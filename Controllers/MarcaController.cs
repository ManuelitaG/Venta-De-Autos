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
  [RoutePrefix("api/Marca")]
  public class MarcaController : ApiController
  {
    [HttpGet]
    [Route("ConsultarTodos")]
    public List<Marca> ConsultarTodos()
    {
      clsMarca marca = new clsMarca();
      return marca.ConsultarTodos();
    }

    [HttpPost]
    [Route("Insertar")]
    public string Insertar([FromBody] Marca marca)
    {
      clsMarca marcas = new clsMarca();
      marcas.marca = marca;

      return marcas.Insertar();
    }
  }
}