using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Session
{
    public class SessionHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext HttpContext
        {
            get { return _httpContextAccessor.HttpContext; }
        }

        public static void AgregarSesion(string usuario, string codigoPersona)
        {
            HttpContext.Session.SetString("User", usuario);
            HttpContext.Session.SetString("UserID", codigoPersona);
        }
        public static bool ExisteUsuarioEnSesion()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("User"));
        }
        public static void EliminarSesion()
        {
            HttpContext.Session.Clear();
        }
        public static string ObtenerUsuario
        {
            get { return HttpContext.Session.GetString("User"); }
        }
        public static string ObtenerCodigoPersona
        {
            get { return HttpContext.Session.GetString("UserID"); }
        }

    }
}
