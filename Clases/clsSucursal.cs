using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class clsSucursal
  {
    private db20311Entities dbVenta = new db20311Entities();
    public Sucursal sucursal { get; set; }

    public List<Sucursal> ConsultarTodos()
    {
      return dbVenta.Sucursal.ToList();
    }

    public String Insertar()
    {
      try
      {
        dbVenta.Sucursal.Add(sucursal);
        dbVenta.SaveChanges();
        return "Se ha ingresado con éxito una sucursal";
      }
      catch (Exception ex)
      {
        return "No se ha podido ingresar la sucursal" + ex.Message;
      }
    }
  }
}