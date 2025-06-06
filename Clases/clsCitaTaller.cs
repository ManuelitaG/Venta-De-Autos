using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{
  public class clsCitaTaller
  {
    private db20311Entities dbVenta = new db20311Entities();
    public CitaTaller citaTaller { get; set; }

        public List<CitaTallerDTO> ConsultarTodos()
        {
            using (var db = new db20311Entities())
            {
                var citas = (from c in db.CitaTaller
                             join cli in db.Cliente on c.DocumentoCliente equals cli.Documento
                             join v in db.Vehiculo on c.CodigoVehiculo equals v.Codigo
                             join m in db.Modelo on v.IdModelo equals m.Id
                             join ma in db.Marca on m.IdMarca equals ma.Id
                             select new CitaTallerDTO
                             {
                                 Id = c.Id,
                                 DocumentoCliente = c.DocumentoCliente,
                                 NombreCompletoCliente = cli.Nombre + " " + cli.Apellidos,
                                 CodigoVehiculo = c.CodigoVehiculo,
                                 MarcaNombre = ma.Nombre,
                                 ModeloNombre = m.Nombre,
                                 Año = v.Año,
                                 FechaCita = c.FechaCita,
                                 Motivo = c.Motivo,
                                 Estado = c.Estado,
                                 Observaciones = c.Observaciones,
                                 IdReclamoGarantia = c.IdReclamoGarantia
                             }).ToList();

                return citas;
            }
        }
        public List<CitaTallerDTO> ConsultarPendientes()
        {
            using (var db = new db20311Entities())
            {
                var citas = (from c in db.CitaTaller
                             join cli in db.Cliente on c.DocumentoCliente equals cli.Documento
                             join v in db.Vehiculo on c.CodigoVehiculo equals v.Codigo
                             join m in db.Modelo on v.IdModelo equals m.Id
                             join ma in db.Marca on m.IdMarca equals ma.Id
                             where c.Estado == "Pendiente"
                             select new CitaTallerDTO
                             {
                                 Id = c.Id,
                                 DocumentoCliente = c.DocumentoCliente,
                                 NombreCompletoCliente = cli.Nombre + " " + cli.Apellidos,
                                 CodigoVehiculo = c.CodigoVehiculo,
                                 MarcaNombre = ma.Nombre,
                                 ModeloNombre = m.Nombre,
                                 Año = v.Año,
                                 FechaCita = c.FechaCita,
                                 Motivo = c.Motivo,
                                 Estado = c.Estado,
                                 Observaciones = c.Observaciones,
                                 IdReclamoGarantia = c.IdReclamoGarantia
                             }).ToList();

                return citas;
            }
        }





        public string Insertar()
    {
        try
        {
            if (string.IsNullOrEmpty(citaTaller.Estado))
                citaTaller.Estado = "Pendiente";

            if (citaTaller.CodigoVehiculo == 0)
                citaTaller.CodigoVehiculo = 1; 

            if (citaTaller.FechaCita == default(DateTime))
                citaTaller.FechaCita = DateTime.Now;

            dbVenta.CitaTaller.Add(citaTaller);
            dbVenta.SaveChanges();
            return "Se ha ingresado con éxito la cita del taller";
        }
        catch (Exception ex)
        {
            return "No se ha podido ingresar la cita del taller: " + ex.Message;
        }
    }

        public class CitaTallerDTO
        {
            public int Id { get; set; }
            public string DocumentoCliente { get; set; }
            public string NombreCompletoCliente { get; set; }
            public int CodigoVehiculo { get; set; }
            public string MarcaNombre { get; set; }
            public string ModeloNombre { get; set; }
            public int Año { get; set; }
            public DateTime FechaCita { get; set; }
            public string Motivo { get; set; }
            public string Estado { get; set; }
            public string Observaciones { get; set; }
            public int? IdReclamoGarantia { get; set; }
        }




    }
}