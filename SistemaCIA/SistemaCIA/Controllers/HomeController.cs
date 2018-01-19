using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaCIA.Models;
using SistemaCIA.Models.Login;
using SistemaCIA.Models.ContextDb;
using Microsoft.AspNetCore.Http;
using SistemaCIA.Models.Session;

namespace SistemaCIA.Controllers
{
    [AutenticadoAttribute]
    public class HomeController : Controller
    {
        private readonly SistemaCIADBContext _context;
        public HomeController(SistemaCIADBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.msj = HttpContext.Session.GetString("User");
            return View();
        }

        //[PermisoAttribute(Permiso = RolesPermisos.LiderDeCelula)]
        public IActionResult About()
        {
            ViewData["Message"] = SessionHelper.ObtenerUsuario;
            return View();
        }

        [PermisoAttribute(Permiso = RolesPermisos.LiderDeCelula)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
