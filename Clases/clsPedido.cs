using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class clsPedido
  {
    private db20311Entities dbVenta = new db20311Entities();

    public PedidoCliente pedido { get; set; }
    public List<DetallePedidoCliente> detalles { get; set; } = new List<DetallePedidoCliente>();

    public string Insertar()
    {
      try
      {
        pedido.FechaPedido = DateTime.Now;

        dbVenta.PedidoCliente.Add(pedido);
        dbVenta.SaveChanges();

        foreach (var detalle in detalles)
        {
          var vehiculo = dbVenta.Vehiculo.FirstOrDefault(v => v.Codigo == detalle.CodigoVehiculo);

          if (vehiculo != null)
          {
            detalle.IdPedido = pedido.Id;
            detalle.PrecioUnitario = vehiculo.ValorUnitario;

            dbVenta.DetallePedidoCliente.Add(detalle);
          }
          else
          {
            return $"Vehículo con código {detalle.CodigoVehiculo} no encontrado.";
          }
        }

        dbVenta.SaveChanges();

        return "Se ha registrado exitosamente el pedido";
      }
      catch (Exception ex)
      {
        return "No se ha podido registrar el pedido: " + ex.Message;
      }
    }

    public List<object> ConsultarXCliente(string idCliente)
    {
      return dbVenta.PedidoCliente
          .Where(p => p.DocumentoCliente == idCliente)
          .Select(p => new
          {
            p.Id,
            p.FechaPedido,
            p.Estado
          })
          .ToList<object>();
    }
  }
}