using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using VentaAutos.Models;
using System.Data.Entity;

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
                pedido.Estado = "Pendiente";

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
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var errores = ex.EntityValidationErrors
                    .SelectMany(e => e.ValidationErrors)
                    .Select(e => $"{e.PropertyName}: {e.ErrorMessage}")
                    .ToList();
                return "No se ha podido registrar el pedido (Validación): " + string.Join(" | ", errores);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                {
                    msg += " | Inner: " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        msg += " | Inner2: " + ex.InnerException.InnerException.Message;
                    }
                }
                return "No se ha podido registrar el pedido: " + msg;
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

        public List<object> ConsultarTodos()
        {
            var pedidos = dbVenta.PedidoCliente
                .Include(p => p.Cliente)
                .Include(p => p.DetallePedidoCliente.Select(d => d.Vehiculo.Modelo.Marca)) 
                .Select(p => new
                {
                    p.Id,
                    p.DocumentoCliente,
                    NombreCliente = p.Cliente != null ? p.Cliente.Nombre + " " + p.Cliente.Apellidos : "(Sin cliente)",
                    p.FechaPedido,
                    p.Estado,
                    p.Observaciones,
                    Detalles = p.DetallePedidoCliente.Select(d => new
                    {
                        d.CodigoVehiculo,
                        Vehiculo = d.Vehiculo != null && d.Vehiculo.Modelo != null && d.Vehiculo.Modelo.Marca != null
                            ? (d.Vehiculo.Modelo.Marca.Nombre + " " + d.Vehiculo.Modelo.Nombre + " " + d.Vehiculo.Año)
                            : "(Sin vehículo)",
                        d.Cantidad,
                        ValorUnitario = d.PrecioUnitario,
                        Total = d.Cantidad * d.PrecioUnitario
                    }).ToList()
                })
                .ToList<object>();

            return pedidos;
        }

        public string Actualizar(PedidoCliente pedido)
        {
            try
            {
                var pedidoDb = dbVenta.PedidoCliente.Find(pedido.Id);
                if (pedidoDb == null)
                    return "Pedido no encontrado";

                
                pedidoDb.Estado = pedido.Estado;
                pedidoDb.Observaciones = pedido.Observaciones;
                dbVenta.SaveChanges();
                return "Pedido actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error actualizando el pedido: " + ex.Message;
            }
        }
    }
}
