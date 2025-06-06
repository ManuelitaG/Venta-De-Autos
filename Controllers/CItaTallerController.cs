using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VentaAutos.Clases;
using VentaAutos.Models;
using static VentaAutos.Clases.clsCitaTaller;

namespace VentaAutos.Controllers
{
    [RoutePrefix("api/CitaTaller")]
    public class CItaTallerController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<CitaTallerDTO> ConsultarTodos()
        {
            clsCitaTaller clsCitaTaller = new clsCitaTaller();
            return clsCitaTaller.ConsultarTodos();
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] CitaTaller citaTaller)
        {
            clsCitaTaller clscitaTaller = new clsCitaTaller();
            clscitaTaller.citaTaller = citaTaller;

            return clscitaTaller.Insertar();
        }
        [HttpPost]
        [Route("Cancelar/{id}")]
        public string Cancelar(int id)
        {
            var db = new db20311Entities();
            var cita = db.CitaTaller.FirstOrDefault(c => c.Id == id);
            if (cita == null) return "Cita no encontrada.";

            cita.Estado = "Cancelada";
            db.SaveChanges();
            return "La cita fue cancelada correctamente.";
        }
        [HttpGet]
        [Route("ConsultarPendientes")]
        public List<CitaTallerDTO> ConsultarPendientes()
        {
            clsCitaTaller clsCitaTaller = new clsCitaTaller();
            return clsCitaTaller.ConsultarPendientes();
        }

        [HttpPost]
        [Route("Rechazar/{id}")]
        public string Rechazar(int id, [FromBody] string observaciones)
        {
            using (var db = new db20311Entities())
            {
                var cita = db.CitaTaller.FirstOrDefault(c => c.Id == id);
                if (cita == null) return "Cita no encontrada.";

                cita.Estado = "Rechazada";
                cita.Observaciones = observaciones;
                db.SaveChanges();
                return "La cita fue rechazada correctamente.";
            }
        }
        [HttpPost]
        [Route("Aprobar")]
        public string Aprobar([FromBody] AprobarCitaRequest req)
        {
            using (var db = new db20311Entities())
            {
                var cita = db.CitaTaller.FirstOrDefault(c => c.Id == req.IdCita);
                if (cita == null) return "Cita no encontrada.";

                cita.Estado = "Aprobada";
                cita.Observaciones = req.Observaciones;

                // Si se requiere crear un reclamo de garantía
                if (req.EsPorGarantia)
                {
                    // Busca garantía activa del vehículo
                    var garantia = db.Garantia.FirstOrDefault(g =>
                        g.CodigoVehiculo == cita.CodigoVehiculo &&
                        g.Estado == "Activa" &&
                        g.FechaInicio <= DateTime.Now &&
                        g.FechaFin >= DateTime.Now
                    );
                    if (garantia == null) return "No hay garantía activa para este vehículo.";

                    // Crear reclamo
                    var reclamo = new ReclamoGarantia
                    {
                        IdGarantia = garantia.Id,
                        FechaReclamo = DateTime.Now,
                        DescripcionProblema = req.DescripcionProblema,
                        Estado = "Pendiente"
                    };
                    db.ReclamoGarantia.Add(reclamo);
                    db.SaveChanges();

                    cita.IdReclamoGarantia = reclamo.Id;
                }

                db.SaveChanges();
                return req.EsPorGarantia ?
                    "La cita fue aprobada y el reclamo de garantía fue creado."
                    : "La cita fue aprobada correctamente.";
            }
        }
        [HttpPost]
        [Route("Finalizar/{id}")]
        public string Finalizar(int id, [FromBody] string observaciones)
        {
            using (var db = new db20311Entities())
            {
                var cita = db.CitaTaller.FirstOrDefault(c => c.Id == id);
                if (cita == null) return "Cita no encontrada.";

                cita.Estado = "Finalizada";
                cita.Observaciones = observaciones;
                db.SaveChanges();
                return "Servicio y precio guardados correctamente en la cita.";
            }
        }


        // Clase auxiliar para el request:
        public class AprobarCitaRequest
        {
            public int IdCita { get; set; }
            public string Observaciones { get; set; }
            public bool EsPorGarantia { get; set; }
            public string DescripcionProblema { get; set; }
        }



    }
}