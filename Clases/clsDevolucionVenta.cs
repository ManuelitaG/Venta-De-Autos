using System;
using System.Collections.Generic;
using System.Linq;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
    public class clsDevolucionVenta
    {
        private db20311Entities dbVenta = new db20311Entities();
        public DevolucionVenta devolucionVenta { get; set; }

        public List<DevolucionVenta> ConsultarTodos()
        {
            return dbVenta.DevolucionVenta.ToList();
        }

        public String Insertar()
        {
            try
            {
                dbVenta.DevolucionVenta.Add(devolucionVenta);
                dbVenta.SaveChanges();
                return "Se ha ingresado con éxito una devolución de una venta";
            }
            catch (Exception ex)
            {
                return "No se ha podido ingresar la devolución de la venta" + ex.Message;
            }
        }
    }
}