using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

    public string Registrar(int idModelo, int año, string tipo, int valor, string estado, string origen, string condicion)
    {
      try
      {
        var nuevoVehiculo = new Vehiculo
        {
          IdModelo = idModelo,
          Año = año,
          Tipo = tipo,
          ValorUnitario = valor,
          Estado = estado,
          Origen = origen,
          Condicion = condicion,
          FechaIngreso = DateTime.Now
        };

        dbVenta.Vehiculo.Add(nuevoVehiculo);
        dbVenta.SaveChanges();
        return "Vehículo registrado exitosamente.";
      }
      catch (Exception ex)
      {
        return "Error al registrar el vehículo: " + ex.Message;
      }
    }

  }
}