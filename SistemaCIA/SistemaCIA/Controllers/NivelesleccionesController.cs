using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCIA.Models.ContextDb;

namespace SistemaCIA.Controllers
{
    public class NivelesleccionesController : Controller
    {
        private readonly SistemaCIADBContext _context;

        public NivelesleccionesController(SistemaCIADBContext context)
        {
            _context = context;
        }

        // GET: Niveleslecciones
        public async Task<IActionResult> Index()
        {
            var sistemaCIADBContext = _context.Niveleslecciones.Include(n => n.CodigoNivelNavigation);
            return View(await sistemaCIADBContext.ToListAsync());
        }

        // GET: Niveleslecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var niveleslecciones = await _context.Niveleslecciones
                .Include(n => n.CodigoNivelNavigation)
                .SingleOrDefaultAsync(m => m.CodigoNivelLeccion == id);
            if (niveleslecciones == null)
            {
                return NotFound();
            }

            return View(niveleslecciones);
        }

        // GET: Niveleslecciones/Create
        public IActionResult Create()
        {
            ViewData["CodigoNivel"] = new SelectList(_context.Niveles, "CodigoNivel", "Nombre");
            return View();
        }

        // POST: Niveleslecciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoNivelLeccion,CodigoNivel,Nombre,Descripcion,NumeroLeccion")] Niveleslecciones niveleslecciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(niveleslecciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoNivel"] = new SelectList(_context.Niveles, "CodigoNivel", "Nombre", niveleslecciones.CodigoNivel);
            return View(niveleslecciones);
        }

        // GET: Niveleslecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var niveleslecciones = await _context.Niveleslecciones.SingleOrDefaultAsync(m => m.CodigoNivelLeccion == id);
            if (niveleslecciones == null)
            {
                return NotFound();
            }
            ViewData["CodigoNivel"] = new SelectList(_context.Niveles, "CodigoNivel", "Nombre", niveleslecciones.CodigoNivel);
            return View(niveleslecciones);
        }

        // POST: Niveleslecciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoNivelLeccion,CodigoNivel,Nombre,Descripcion,NumeroLeccion")] Niveleslecciones niveleslecciones)
        {
            if (id != niveleslecciones.CodigoNivelLeccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(niveleslecciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelesleccionesExists(niveleslecciones.CodigoNivelLeccion))
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
            ViewData["CodigoNivel"] = new SelectList(_context.Niveles, "CodigoNivel", "Nombre", niveleslecciones.CodigoNivel);
            return View(niveleslecciones);
        }

        // GET: Niveleslecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var niveleslecciones = await _context.Niveleslecciones
                .Include(n => n.CodigoNivelNavigation)
                .SingleOrDefaultAsync(m => m.CodigoNivelLeccion == id);
            if (niveleslecciones == null)
            {
                return NotFound();
            }

            return View(niveleslecciones);
        }

        // POST: Niveleslecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var niveleslecciones = await _context.Niveleslecciones.SingleOrDefaultAsync(m => m.CodigoNivelLeccion == id);
            _context.Niveleslecciones.Remove(niveleslecciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelesleccionesExists(int id)
        {
            return _context.Niveleslecciones.Any(e => e.CodigoNivelLeccion == id);
        }
    }
}
