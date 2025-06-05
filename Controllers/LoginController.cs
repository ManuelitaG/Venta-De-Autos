using VentaAutos.Clases;
using VentaAutos.Models;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace VentaAutos.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        [AllowAnonymous]
        [ResponseType(typeof(LoginRespuesta))]
        public IHttpActionResult Ingresar([FromBody] Login credenciales)
        {
            // 1. Validación de datos
            if (credenciales == null || !ModelState.IsValid)
            {
                return Ok(new LoginRespuesta
                {
                    Autenticado = false,
                    Mensaje = "Debe ingresar usuario y clave.",
                    Perfiles = new System.Collections.Generic.List<string>()
                });
            }

            try
            {
                clsLogin _login = new clsLogin();
                LoginRespuesta resultado = _login.Autenticar(credenciales);
                // Devuelve SIEMPRE HTTP 200, el frontend lee Autenticado y Mensaje
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("Error en LoginController.Ingresar: " + ex.ToString());
                return Ok(new LoginRespuesta
                {
                    Autenticado = false,
                    Mensaje = "Ocurrió un error inesperado. Intente más tarde.",
                    Perfiles = new System.Collections.Generic.List<string>()
                });
            }
        }
    }
}
