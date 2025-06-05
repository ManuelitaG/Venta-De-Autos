using System.Linq;
using System.Web.Http;
using VentaAutos.Models;

namespace VentaAutos.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("ObtenerDocumentoPorUsername/{username}")]
        public IHttpActionResult ObtenerDocumentoPorUsername(string username)
        {
            using (var db = new db20311Entities())
            {
                var usuario = db.Usuario.FirstOrDefault(u => u.Username == username);
                if (usuario != null)
                    return Ok(usuario.DocumentoEmpleado);
                else
                    return NotFound();
            }
        }
    }
}
