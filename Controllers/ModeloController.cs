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
  [RoutePrefix("api/Modelo")]
  public class ModeloController : ApiController
  {
    [HttpGet]
    [Route("ConsultarTodos")]
    public List<Modelo> ConsultarTodos()
    {
      clsModelo modelo = new clsModelo();
      return modelo.ConsultarTodos();
    }

    [HttpPost]
    [Route("Insertar")]
    public string Insertar([FromBody] Modelo modelo)
    {
      clsModelo modelos = new clsModelo();
      modelos.modelo = modelo;

      return modelos.Insertar();
    }
  }
}