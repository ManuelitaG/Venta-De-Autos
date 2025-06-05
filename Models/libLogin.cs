using System.Collections.Generic;

namespace VentaAutos.Models
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
    public class LoginRespuesta
    {
        public string Usuario { get; set; }
        public string Perfil { get; set; }
        public string PaginaInicio { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; }
        public List<string> Perfiles { get; set; } 
    }
}
