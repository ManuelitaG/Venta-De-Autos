using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
    public class clsNotaCredito
    {
        private db20311Entities dbVenta = new db20311Entities();
        public NotaCredito notaCredito { get; set; }

        public List<NotaCredito> ConsultarTodos()
        {
            return dbVenta.NotaCredito.ToList();
        }

        public String Insertar()
        {
            try
            {
                dbVenta.NotaCredito.Add(notaCredito);
                dbVenta.SaveChanges();
                return "Se ha ingresado con éxito una nota credito";
            }
            catch (Exception ex)
            {
                return "No se ha podido ingresar una nota credito" + ex.Message;
            }


        }
    }
}