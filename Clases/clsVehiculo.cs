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

        public List<VehiculoDisponibleDTO> ListarDisponibles()
        {
            var disponibles = (from v in dbVenta.Vehiculo
                               join m in dbVenta.Modelo on v.IdModelo equals m.Id
                               join ma in dbVenta.Marca on m.IdMarca equals ma.Id
                               where v.Estado == "Disponible"
                               select new VehiculoDisponibleDTO
                               {
                                   Codigo = v.Codigo,
                                   IdModelo = m.Id,
                                   ModeloNombre = m.Nombre,
                                   MarcaNombre = ma.Nombre,
                                   Año = v.Año,
                                   Tipo = v.Tipo,
                                   ValorUnitario = v.ValorUnitario,
                                   Estado = v.Estado,
                                   Origen = v.Origen,
                                   Condicion = v.Condicion
                               }).ToList();

            return disponibles;
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