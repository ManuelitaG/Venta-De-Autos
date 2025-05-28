using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
    public class clsDetalleDevolucion
    {
        private db20311Entities dbVenta = new db20311Entities();
        public DetalleDevolucion detalleDevolucion { get; set; }

        public List<DetalleDevolucion> ConsultarTodos()
        {
            return dbVenta.DetalleDevolucion.ToList();
        }

        public String Insertar()
        {
            try
            {
                dbVenta.DetalleDevolucion.Add(detalleDevolucion);
                dbVenta.SaveChanges();
                return "Se ha ingresado con éxito el detalle de una devolucion";
            }
            catch (Exception ex)
            {
                return "No se ha podido ingresar el detalle de la devolucion" + ex.Message;
            }


        }
    }
}