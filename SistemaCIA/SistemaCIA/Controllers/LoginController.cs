using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SistemaCIA.Models.ContextDb;
using SistemaCIA.Models.Login;
using SistemaCIA.Models.Services;
using SistemaCIA.Models.Session;

namespace SistemaCIA.Controllers
{
    public class LoginController : Controller
    {
        private readonly SistemaCIADBContext _context;

        public LoginController(SistemaCIADBContext context)
        {
            _context = context;
        }

        // GET: Login
        [NoLoginAttribute]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var clave = Encriptar.Encripta(login.Clave);
                var usuario = _context.Usuarios.SingleOrDefault(x => x.Usuario == login.Usuario && x.Clave == clave);
                if (usuario != null)
                {
                    SessionHelper.AgregarSesion(usuario.Usuario, usuario.CodigoPersona);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.msj = "Usuario o contraseña incorrectos.";
                }
            }
            return View(login);
        }

        public ActionResult CerrarSesion()
        {
            SessionHelper.EliminarSesion();
            return RedirectToAction(nameof(Login));
        }
    }
}