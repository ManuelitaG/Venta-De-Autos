using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class clsModelo
  {
    private db20311Entities dbVenta = new db20311Entities();
    public Modelo modelo { get; set; }

    public List<Modelo> ConsultarTodos()
    {
      return dbVenta.Modelo.ToList();
    }

    public String Insertar()
    {
      try
      {
        dbVenta.Modelo.Add(modelo);
        dbVenta.SaveChanges();
        return "Se ha registrado exitosamente el modelo";
      }
      catch (Exception ex)
      {
        return "No se ha podido registrar el modelo" + ex.Message;
      }
    }
  }
}