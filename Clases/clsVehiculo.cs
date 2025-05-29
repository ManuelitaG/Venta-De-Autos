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

    public string Registrar()
    {
      try
      {
        vehiculo.FechaIngreso = DateTime.Now;

        dbVenta.Vehiculo.Add(vehiculo);
        dbVenta.SaveChanges();

        return "Se ha registrado exitosamente el vehículo";
      }
      catch (Exception ex)
      {
        return "No se ha podido registrar el vehículo: " + ex.Message;
      }
    }

    public string Actualizar(int idVehiculo, Vehiculo nuevosDatos)
    {
      try
      {
        Vehiculo vehiculo = dbVenta.Vehiculo.FirstOrDefault(v => v.Codigo == idVehiculo);
        if (vehiculo == null)
        {
          return "No se encontró un vehiculo con codigo: " + idVehiculo;
        }

      
        vehiculo.Estado = nuevosDatos.Estado;
        vehiculo.ValorUnitario = nuevosDatos.ValorUnitario;

        dbVenta.SaveChanges();
        return "Vehiculo actualizado exitosamente";
      }
      catch (Exception ex)
      {
        return "Error al actualizar el vehiculo: " + ex.Message;
      }
    }
  }
}