using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
    public class clsServicioTaller
    {
        private db20311Entities dbVenta = new db20311Entities();
        public ServicioTaller servicioTaller { get; set; }

        public List<ServicioTaller> ConsultarTodos()
        {
            return dbVenta.ServicioTaller.ToList();
        }

        public String Insertar()
        {
            try
            {
                if (ConsultarXIdCita(servicioTaller.IdCita) != null) 
                {
                    return "No se ha podido ingresar el servicio del taller (IdCita incorrecto)";
                }
                dbVenta.ServicioTaller.Add(servicioTaller);
                dbVenta.SaveChanges();
                return "Se ha ingresado con éxito el servicio del taller";
            }
            catch (Exception ex)
            {
                return "No se ha podido ingresar el servicio del taller" + ex.Message;
            }


        }
        public ServicioTaller ConsultarXIdCita(int cita)
        {
            return dbVenta.ServicioTaller.FirstOrDefault(e => e.IdCita == cita);
        }
    }
}