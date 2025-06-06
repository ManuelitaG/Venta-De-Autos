using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VentaAutos.Clases
{
    public class GarantiaDTO
    {
        public int Id { get; set; }
        public int CodigoVehiculo { get; set; }
        public string MarcaNombre { get; set; }
        public string ModeloNombre { get; set; }
        public int Año { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Cobertura { get; set; }
        public string Estado { get; set; }
    }


}