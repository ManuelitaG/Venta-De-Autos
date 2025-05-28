using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
    public class clsReclamoGarantia
    {
        private db20311Entities dbVenta = new db20311Entities();
        public ReclamoGarantia reclamoGarantia { get; set; }

        public List<ReclamoGarantia> ConsultarTodos()
        {
            return dbVenta.ReclamoGarantia.ToList();
        }

        public String Insertar()
        {
            try
            {
                dbVenta.ReclamoGarantia.Add(reclamoGarantia);
                dbVenta.SaveChanges();
                return "Se ha ingresado con éxito un reclamo de la garantía";
            }
            catch (Exception ex)
            {
                return "No se ha podido ingresar el reclamo de la garantía" + ex.Message;
            }


        }

       
    }
}