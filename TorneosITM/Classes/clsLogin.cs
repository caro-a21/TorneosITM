using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TorneosITM.Models;
using static TorneosITM.Models.libLogin;

namespace TorneosITM.Classes
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }

        public DBTorneosITMEntities dbTorneo = new DBTorneosITMEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }

        public IQueryable<LoginRespuesta> Ingresar()
        {
            try
            {
                // Verificar si el usuario existe en la base de datos
                var administrador = dbTorneo.AdministradorITMs
                    .FirstOrDefault(a => a.Usuario == login.Usuario);

                if (administrador == null)
                {
                    // Usuario no encontrado
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario incorrecto";
                    return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
                }

                // Verificar si la contraseña es correcta
                if (administrador.Clave != login.Clave)
                {
                    // Contraseña incorrecta
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Contraseña incorrecta";
                    return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
                }

                // Generar token si el usuario es válido
                string token = TokenGenerator.GenerateTokenJwt(administrador.Usuario);

                // Respuesta exitosa
                return new List<LoginRespuesta>
                {
                    new LoginRespuesta
                    {
                        Usuario = administrador.Usuario,
                        Autenticado = true,
                        Perfil = "Administrador",
                        PaginaInicio = "paginaAdministrador.html",
                        Token = token
                    }
                }.AsQueryable();
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
            }
        }
    }
}