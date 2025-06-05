using System.Collections.Generic;
using System.Linq;
using System;
using VentaAutos.Clases;
using VentaAutos.Models;

public class clsLogin
{
    private db20311Entities db = new db20311Entities();

    public LoginRespuesta Autenticar(Login credenciales)
    {
        var respuesta = new LoginRespuesta
        {
            Autenticado = false,
            Token = null,
            Mensaje = "",
            Usuario = credenciales.Usuario,
            Perfiles = new List<string>()
        };

        if (string.IsNullOrEmpty(credenciales?.Usuario) || string.IsNullOrEmpty(credenciales.Clave))
        {
            respuesta.Mensaje = "El Usuario y la Clave son obligatorios.";
            return respuesta;
        }

        try
        {
            var usuario = db.Usuario.FirstOrDefault(u =>
                u.Username == credenciales.Usuario &&
                u.Clave == credenciales.Clave);

            if (usuario != null)
            {
                respuesta.Autenticado = true;
                respuesta.Mensaje = "Autenticación exitosa.";
                respuesta.Usuario = usuario.Username;
                respuesta.Token = TokenGenerator.GenerateTokenJwt(usuario.Username);

                // Trae todos los perfiles activos
                respuesta.Perfiles = usuario.Usuario_Perfil
                    .Where(up => up.Activo)
                    .Select(up => up.Perfil.Nombre)
                    .ToList();

                // Si tienes una lógica de perfil principal:
                respuesta.Perfil = respuesta.Perfiles.FirstOrDefault(); // Primer perfil (opcional)
                // Puedes también llenar PaginaInicio aquí si lo deseas
            }
            else
            {
                respuesta.Mensaje = "Credenciales inválidas. Verifique el usuario y la clave.";
            }
        }
        catch (Exception ex)
        {
            respuesta.Mensaje = ex.ToString();
        }

        return respuesta;
    }
}
