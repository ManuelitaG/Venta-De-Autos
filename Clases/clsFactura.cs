using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class clsFactura
  {
    private db20311Entities dbVenta = new db20311Entities();

    public FacturaVenta GenerarFacturaDesdePedido(int numeroPedido, string documentoEmpleado)
    {
      var pedido = dbVenta.PedidoCliente.FirstOrDefault(p => p.Id == numeroPedido && p.Estado == "Aprobado");

      if (pedido == null)
      {
        throw new Exception("El pedido no existe o no está aprobado.");
      }

      var empleadoCargo = dbVenta.EmpleadoCargo
          .FirstOrDefault(e => e.DocumentoEmpleado == documentoEmpleado && e.FechaFin == null);

      if (empleadoCargo == null)
      {
        throw new Exception("No se encontró el empleado activo.");
      }

      FacturaVenta factura = new FacturaVenta
      {
        DocumentoCliente = pedido.DocumentoCliente,
        CodigoEmpleadoCargo = empleadoCargo.Codigo,
        Fecha = DateTime.Now,
        DetalleFacturaVenta = new List<DetalleFacturaVenta>()
      };

      foreach (var detallePedido in pedido.DetallePedidoCliente)
      {
        var vehiculo = dbVenta.Vehiculo.Find(detallePedido.CodigoVehiculo);

        if (vehiculo != null)
        {
          var detalleFactura = new DetalleFacturaVenta
          {
            CodigoVehiculo = vehiculo.Codigo,
            Cantidad = detallePedido.Cantidad,
            ValorUnitario = vehiculo.ValorUnitario
          };
          factura.DetalleFacturaVenta.Add(detalleFactura);
        }
      }

      dbVenta.FacturaVenta.Add(factura);
      dbVenta.SaveChanges();

      return factura;
    }
  }

}