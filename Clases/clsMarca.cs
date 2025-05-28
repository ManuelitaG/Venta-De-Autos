using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class clsMarca
  {
    private db20311Entities dbVenta = new db20311Entities();
    public Marca marca { get; set; }

    public List<Marca> ConsultarTodos()
    {
      return dbVenta.Marca.ToList();
    }

    public String Insertar()
    {
      try
      {
        dbVenta.Marca.Add(marca);
        dbVenta.SaveChanges();
        return "Se ha registrado exitosamente la marca";
      }
      catch (Exception ex)
      {
        return "No se ha podido registrar la marca" + ex.Message;
      }
    }
  }
}