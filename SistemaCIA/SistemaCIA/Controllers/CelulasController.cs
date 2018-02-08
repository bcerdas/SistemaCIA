using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCIA.Models.Cells;
using SistemaCIA.Models.ContextDb;
using SistemaCIA.Models.Session;

namespace SistemaCIA.Controllers
{
    public class CelulasController : Controller
    {
        private readonly SistemaCIADBContext _context;

        public CelulasController(SistemaCIADBContext context)
        {
            _context = context;
        }

        // GET: Celulas
        public async Task<IActionResult> Index()
        {
            var sistemaCIADBContext = _context.Celulas.Include(c => c.AsistenteNavigation).Include(c => c.CelulaRaizNavigation).Include(c => c.LiderNavigation);
            return View(await sistemaCIADBContext.ToListAsync());
        }

        // GET: Celulas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celulas = await _context.Celulas
                .Include(c => c.AsistenteNavigation)
                .Include(c => c.CelulaRaizNavigation)
                .Include(c => c.LiderNavigation)
                .SingleOrDefaultAsync(m => m.CodigoCelula == id);
            if (celulas == null)
            {
                return NotFound();
            }

            return View(celulas);
        }

        // GET: Celulas/Create
        public IActionResult AgregarCelula()
        {
            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "Nombre");
            //ViewData["CelulaRaiz"] = new SelectList(_context.Celulas, "CodigoCelula", "CelulaRaizNavigation.Lider");
            ViewData["Lider"] = new SelectList(_context.Personas, "CodigoPersona", "Nombre");

            List<SelectListItem> horas = new List<SelectListItem>();

            //Aqui llenamos el dropdownlist de las horas

            #region AM
            for (int h = 7; h < 12; h++)
            {
                for (int m = 0; m <= 30; m = m + 30)
                {
                    string hora = "";

                    if (h > 9 & m == 0)
                    {
                        hora = h + " : " + "0" + m + " am";
                    }
                    else if(h >= 0 && h < 10 && m < 10)
                    {
                        hora = "0" + h + " : " + "0" + m + " am";
                    }
                    else if (h >= 0 && h < 10)
                    {
                        hora = "0" + h + " : " + m + " am";
                    }
                    else
                    {
                        hora = h + " : " + m + " am";
                    }

                    horas.Add(new SelectListItem() { Text = hora, Value = hora });
                }
            }

            #endregion

            #region MD
            var medioDia = "12 : 00 md";
            horas.Add(new SelectListItem() { Text = medioDia, Value = medioDia });
            medioDia = "12 : 30 pm";
            horas.Add(new SelectListItem() { Text = medioDia, Value = medioDia });
            #endregion

            #region PM
            for (int h = 1; h <= 9; h++)
            {
                for (int m = 0; m <= 30; m = m + 30)
                {
                    string hora = "";

                    if (h >= 0 && h < 10 && m < 10)
                    {
                        hora = "0" + h + " : " + "0" + m + " pm";
                    }
                    else if (h >= 0 && h < 10)
                    {
                        hora = "0" + h + " : " + m + " pm";
                    }
                    else
                    {
                        hora = h + " : " + m + " pm";
                    }

                    horas.Add(new SelectListItem() { Text = hora, Value = hora });
                }
            }
            #endregion

            ViewBag.Horas = horas;

            return View();
        }

        // POST: Celulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarCelula(AgregarCelulaModel celula)
        {
            if (ModelState.IsValid)
            {
                Celulas nuevaCelula = new Celulas() {
                    Lider = celula.Lider,
                    Asistente = celula.Asistente,
                    CelulaRaiz = celula.CelulaRaiz,
                    Dia = celula.Dia,
                    Direccion = celula.Direccion,
                    Hora = celula.Hora,
                    Lugar = celula.Lugar,
                    PromedioPersonas = 0
                };

                _context.Celulas.Add(nuevaCelula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona");
            ViewData["CelulaRaiz"] = new SelectList(_context.Celulas, "CodigoCelula", "CodigoCelula");
            ViewData["Lider"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona");

            return View();
        }


        public IActionResult AgregarInforme( )
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarInforme(Informescelulares informe)
        {
            if (ModelState.IsValid)
            {
                if (SessionHelper.ExisteUsuarioEnSesion())
                {
                    var celula = _context.Celulas.SingleOrDefault(x => x.Lider == SessionHelper.ObtenerCodigoPersona);
                    informe.CodigoCelula = celula.CodigoCelula;
                    _context.Informescelulares.Add(informe);
                    await _context.SaveChangesAsync();
                }  
            }

            return View();//enviar al index de informes
        }

        // GET: Celulas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celulas = await _context.Celulas.SingleOrDefaultAsync(m => m.CodigoCelula == id);
            if (celulas == null)
            {
                return NotFound();
            }
            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", celulas.Asistente);
            ViewData["CelulaRaiz"] = new SelectList(_context.Celulas, "CodigoCelula", "CodigoCelula", celulas.CelulaRaiz);
            ViewData["Lider"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", celulas.Lider);
            return View(celulas);
        }

        // POST: Celulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoCelula,Lider,Asistente,CelulaRaiz,Lugar,Direccion,Hora,Dia,PromedioPersonas")] AgregarCelulaModel celulas)
        {
            if (id != celulas.CodigoCelula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celulas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelulasExists(celulas.CodigoCelula))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", celulas.Asistente);
            ViewData["CelulaRaiz"] = new SelectList(_context.Celulas, "CodigoCelula", "CodigoCelula", celulas.CelulaRaiz);
            ViewData["Lider"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", celulas.Lider);
            return View(celulas);
        }

        // GET: Celulas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celulas = await _context.Celulas
                .Include(c => c.AsistenteNavigation)
                .Include(c => c.CelulaRaizNavigation)
                .Include(c => c.LiderNavigation)
                .SingleOrDefaultAsync(m => m.CodigoCelula == id);
            if (celulas == null)
            {
                return NotFound();
            }

            return View(celulas);
        }

        // POST: Celulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var celulas = await _context.Celulas.SingleOrDefaultAsync(m => m.CodigoCelula == id);
            _context.Celulas.Remove(celulas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelulasExists(string id)
        {
            return _context.Celulas.Any(e => e.CodigoCelula == id);
        }
    }
}
