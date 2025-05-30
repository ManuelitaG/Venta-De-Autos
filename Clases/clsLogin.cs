using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VentaAutos.Models;

namespace VentaAutos.Clases
{

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Clave { get; set; }
        }
        public class LoginResponse
        {
            public bool Autenticado { get; set; }
            public string Mensaje { get; set; }
            public string Token { get; set; }
            public string Username { get; set; }
        }
        public class clsLogin
        {
            private db20311Entities db = new db20311Entities();
            public LoginResponse Autenticar(LoginRequest credenciales)
            {
                LoginResponse respuesta = new LoginResponse { Autenticado = false, Token = null };

                if (string.IsNullOrEmpty(credenciales?.Username) || string.IsNullOrEmpty(credenciales.Clave))
                {
                    respuesta.Mensaje = "El Usuario y la Clave son obligatorios.";
                    return respuesta;
                }

                try
                {
                    var admin = db.Usuario.FirstOrDefault(a =>
                                    a.Username == credenciales.Username &&
                                    a.Clave == credenciales.Clave);

                    if (admin != null)
                    {
                        respuesta.Autenticado = true;
                        respuesta.Mensaje = "Autenticación exitosa.";
                        respuesta.Username = admin.Username;

                        respuesta.Token = TokenGenerator.GenerateTokenJwt(admin.Username);
                    }
                    else
                    {
                        respuesta.Mensaje = "Credenciales inválidas. Verifique el usuario y la clave.";
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.TraceError("Error en clsLogin.Autenticar: " + ex.ToString());

                    respuesta.Mensaje = "Ocurrió un error inesperado durante el proceso de autenticación.";
                }

                return respuesta;
            }
        }
    }

