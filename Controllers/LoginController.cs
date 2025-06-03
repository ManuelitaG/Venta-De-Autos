using VentaAutos.Clases;
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
        [ResponseType(typeof(LoginResponse))]
        public IHttpActionResult Ingresar([FromBody] LoginRequest credenciales)
        {
            // 1. Validación de datos
            if (credenciales == null || !ModelState.IsValid)
            {
                return Ok(new LoginResponse
                {
                    Autenticado = false,
                    Mensaje = "Debe ingresar usuario y clave."
                });
            }

            try
            {
                clsLogin _login = new clsLogin();
                LoginResponse resultado = _login.Autenticar(credenciales);
                // 2. Devuelve SIEMPRE HTTP 200, el frontend lee Autenticado y Mensaje
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // 3. No envíes el mensaje técnico, solo uno general
                System.Diagnostics.Trace.TraceError("Error en LoginController.Ingresar: " + ex.ToString());
                return Ok(new LoginResponse
                {
                    Autenticado = false,
                    Mensaje = "Ocurrió un error inesperado. Intente más tarde."
                });
            }
        }
    }
}
