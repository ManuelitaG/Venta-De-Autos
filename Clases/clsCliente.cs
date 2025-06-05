using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class clsCliente
  {
    private db20311Entities dbVenta = new db20311Entities();
    public Cliente cliente { get; set; }

    public List<Cliente> ConsultarTodos()
    {
      return dbVenta.Cliente.ToList();
    }

    public String Registrar()
    {
      try
      {
        dbVenta.Cliente.Add(cliente);
        dbVenta.SaveChanges();
        return "Se ha registrado exitosamente el cliente";
      }
      catch (Exception ex)
      {
        return "No se ha podido registrar el cliente" + ex.Message;
      }
    }
  }
}