//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VentaAutos.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleFacturaVenta
    {
        public int Codigo { get; set; }
        public int NumeroFactura { get; set; }
        public int CodigoVehiculo { get; set; }
        public int Cantidad { get; set; }
        public int ValorUnitario { get; set; }

        [JsonIgnore]
        public virtual Vehiculo Vehiculo { get; set; }

        [JsonIgnore]
        public virtual FacturaVenta FacturaVenta { get; set; }
    }
}
