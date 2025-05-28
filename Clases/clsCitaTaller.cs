using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class clsCitaTaller
  {
    private db20311Entities dbVenta = new db20311Entities();
    public CitaTaller citaTaller { get; set; }

    public List<CitaTaller> ConsultarTodos()
    {
      return dbVenta.CitaTaller.ToList();
    }

    public String Insertar()
    {
      try
      {
        dbVenta.CitaTaller.Add(citaTaller);
        dbVenta.SaveChanges();
        return "Se ha ingresado con éxito la cita del taller";
      }
      catch (Exception ex)
      {
        return "No se ha podido ingresar la cita del taller" + ex.Message;
      }
    }
  }
}