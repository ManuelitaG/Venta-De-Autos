using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VentaAutos.Clases;
using VentaAutos.Models;

namespace VentaAutos.Controllers
{
  [RoutePrefix("api/Vehiculo")]
  public class VehiculoController : ApiController
  {
   [EnableCors(origins: "*", headers: "*", methods: "*")]

        [HttpGet]
        [Route("ListarDisponibles")]
        public IHttpActionResult ListarDisponibles()
        {
            using (var db = new db20311Entities())
            {
                var lista = db.Vehiculo
                    .Select(v => new
                    {
                        v.Codigo,
                        v.Año,
                        v.Tipo,
                        v.ValorUnitario,
                        v.Estado,
                        v.Origen,
                        v.Condicion,
                        v.IdModelo,
                        ModeloNombre = v.Modelo.Nombre,
                        MarcaNombre = v.Modelo.Marca.Nombre  
                    })
                    .ToList();

                return Ok(lista);
            }
        }


        [HttpPost]
    [Route("Registrar")]
    public string Registrar([FromBody] Vehiculo vehiculo)
    {
      clsVehiculo vehiculos = new clsVehiculo();
      vehiculos.vehiculo = vehiculo;

      return vehiculos.Registrar(); 
    }

    [HttpPut]
    [Route("Actualizar")]
    public string Actualizar([FromBody] Vehiculo vehiculo)
    {
      clsVehiculo vehiculos = new clsVehiculo();
      vehiculos.vehiculo = vehiculo;
      return vehiculos.Actualizar(vehiculo.Codigo, vehiculo);
    }
  }
}