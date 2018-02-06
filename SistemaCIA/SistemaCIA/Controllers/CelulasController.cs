using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCIA.Models.Cells;
using SistemaCIA.Models.ContextDb;

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
            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona");
            ViewData["CelulaRaiz"] = new SelectList(_context.Celulas, "CodigoCelula", "CodigoCelula");
            ViewData["Lider"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona");

            var pepe = _context.Personas.ToList();
            AgregarCelulaModel model = new AgregarCelulaModel();
            model.personas = pepe;

            return View(model);
        }

        // POST: Celulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarCelula([Bind("CodigoCelula,Lider,Asistente,CelulaRaiz,Lugar,Direccion,Hora,Dia,PromedioPersonas")] AgregarCelulaModel celulas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celulas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", celulas.Asistente);
            ViewData["CelulaRaiz"] = new SelectList(_context.Celulas, "CodigoCelula", "CodigoCelula", celulas.CelulaRaiz);
            ViewData["Lider"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", celulas.Lider);
            return View(celulas);
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
