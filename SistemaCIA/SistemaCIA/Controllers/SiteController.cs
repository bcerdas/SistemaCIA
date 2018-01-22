using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SistemaCIA.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult Ministerios()
        {
            return View();
        }

        public IActionResult Pastor()
        {
            return View();
        }

        public IActionResult Contactos()
        {
            return View();
        }

        //GET DE MINISTERIOS

        public IActionResult MAlcance()
        {
            return View();
        }

        public IActionResult MCapacitacion()
        {
            return View();
        }

        public IActionResult MKids()
        {
            return View();
        }

        public IActionResult MAnfitriones()
        {
            return View();
        }

        public IActionResult MFinanzas()
        {
            return View();
        }

        public IActionResult MMisiones()
        {
            return View();
        }

        public IActionResult MSocial()
        {
            return View();
        }

        public IActionResult MComTec()
        {
            return View();
        }

        public IActionResult MIntercesion()
        {
            return View();
        }

        public IActionResult MAlabanza()
        {
            return View();
        }
    }
}