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

        public List<GarantiaDTO> ConsultarGarantias()
        {
            using (var db = new db20311Entities())
            {
                var lista = (from g in db.Garantia
                             join v in db.Vehiculo on g.CodigoVehiculo equals v.Codigo
                             join m in db.Modelo on v.IdModelo equals m.Id
                             join ma in db.Marca on m.IdMarca equals ma.Id
                             select new GarantiaDTO
                             {
                                 Id = g.Id,
                                 CodigoVehiculo = g.CodigoVehiculo,
                                 MarcaNombre = ma.Nombre,
                                 ModeloNombre = m.Nombre,
                                 Año = v.Año,
                                 NumeroFactura = g.NumeroFactura,
                                 FechaInicio = g.FechaInicio,
                                 FechaFin = g.FechaFin,
                                 Cobertura = g.Cobertura,
                                 Estado = g.Estado
                             }).ToList();

                return lista;
            }
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