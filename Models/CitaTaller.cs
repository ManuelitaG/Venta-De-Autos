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
    
    public partial class CitaTaller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CitaTaller()
        {
            this.ServicioTaller = new HashSet<ServicioTaller>();
        }
    
        public int Id { get; set; }
        public string DocumentoCliente { get; set; }
        public int CodigoVehiculo { get; set; }
        public System.DateTime FechaCita { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public Nullable<int> IdReclamoGarantia { get; set; }

        [JsonIgnore]
        public virtual Vehiculo Vehiculo { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
        [JsonIgnore]
        public virtual ReclamoGarantia ReclamoGarantia { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServicioTaller> ServicioTaller { get; set; }
    }
}
