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

    public List<object> ObtenerHistorialCompras(string documentoCliente)
    {
      var historial = (from f in dbVenta.FacturaVenta
                       join df in dbVenta.DetalleFacturaVenta on f.Numero equals df.NumeroFactura
                       join v in dbVenta.Vehiculo on df.CodigoVehiculo equals v.Codigo
                       where f.DocumentoCliente == documentoCliente
                       orderby f.Fecha descending
                       select new
                       {
                         NumeroFactura = f.Numero,
                         FechaCompra = f.Fecha,
                         CodigoVehiculo = v.Codigo,
                         Cantidad = df.Cantidad,
                         ValorUnitario = df.ValorUnitario,
                         Total = df.Cantidad * df.ValorUnitario
                       }).ToList<object>();

      return historial;
    }
  }
}