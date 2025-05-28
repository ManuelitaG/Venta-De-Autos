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
  [RoutePrefix("api/Vehiculo")]
  public class VehiculoController : ApiController
  {
    [HttpGet]
    [Route("ListarDisponibles")]
    public List<Vehiculo> ListarDisponibles()
    {
      clsVehiculo vehiculos = new clsVehiculo();
      return vehiculos.ListarDisponibles();
    }

    [HttpPost]
    [Route("Registrar")]
    public string Registrar([FromBody] Vehiculo vehiculo)
    {
      clsVehiculo vehiculos = new clsVehiculo();
      vehiculos.vehiculo = vehiculo;

      return vehiculos.Registrar(); 
    }

  }
}