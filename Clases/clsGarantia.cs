using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
    public class clsGarantia
    {
        private db20311Entities dbVenta = new db20311Entities();
        public Garantia garantia { get; set; }

        public List<Garantia> ConsultarTodos()
        {
            return dbVenta.Garantia.ToList();
        }

        public String Insertar()
        {
            try
            {
                dbVenta.Garantia.Add(garantia);
                dbVenta.SaveChanges();
                return "Se ha ingresado con éxito una garantía";
            }
            catch (Exception ex)
            {
                return "No se ha podido ingresar la garantía, el vehículo o la factura no existe: " + ex.Message;
            }


        }

        public Garantia ConsultarTodosXPlaca(int codigoVehiculo)
        {
            return dbVenta.Garantia.FirstOrDefault(e => e.CodigoVehiculo == codigoVehiculo);
        }
    }
}