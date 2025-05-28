using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class clsVehiculo
  {
    private db20311Entities dbVenta = new db20311Entities();
    public Vehiculo vehiculo { get; set; }

    public List<Vehiculo> ListarDisponibles()
    {
      return dbVenta.Vehiculo
                 .Where(v => v.Estado == "Disponible")
                 .ToList();
    }
  }
}