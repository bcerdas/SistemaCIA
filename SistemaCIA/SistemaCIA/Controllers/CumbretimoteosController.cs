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
    public class CumbretimoteosController : Controller
    {
        private readonly SistemaCIADBContext _context;

        public CumbretimoteosController(SistemaCIADBContext context)
        {
            _context = context;
        }

        // GET: Cumbretimoteos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cumbretimoteos.ToListAsync());
        }

        // GET: Cumbretimoteos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cumbretimoteos = await _context.Cumbretimoteos
                .SingleOrDefaultAsync(m => m.CodigoCumbreTimoteos == id);
            if (cumbretimoteos == null)
            {
                return NotFound();
            }

            return View(cumbretimoteos);
        }

        // GET: Cumbretimoteos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cumbretimoteos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCumbreTimoteos,Nombre,Lema,Objetivo,FechaInicio,FechaFinal,Asistencia")] Cumbretimoteos cumbretimoteos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cumbretimoteos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cumbretimoteos);
        }

        // GET: Cumbretimoteos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cumbretimoteos = await _context.Cumbretimoteos.SingleOrDefaultAsync(m => m.CodigoCumbreTimoteos == id);
            if (cumbretimoteos == null)
            {
                return NotFound();
            }
            return View(cumbretimoteos);
        }

        // POST: Cumbretimoteos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCumbreTimoteos,Nombre,Lema,Objetivo,FechaInicio,FechaFinal,Asistencia")] Cumbretimoteos cumbretimoteos)
        {
            if (id != cumbretimoteos.CodigoCumbreTimoteos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cumbretimoteos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CumbretimoteosExists(cumbretimoteos.CodigoCumbreTimoteos))
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
            return View(cumbretimoteos);
        }

        // GET: Cumbretimoteos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cumbretimoteos = await _context.Cumbretimoteos
                .SingleOrDefaultAsync(m => m.CodigoCumbreTimoteos == id);
            if (cumbretimoteos == null)
            {
                return NotFound();
            }

            return View(cumbretimoteos);
        }

        // POST: Cumbretimoteos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cumbretimoteos = await _context.Cumbretimoteos.SingleOrDefaultAsync(m => m.CodigoCumbreTimoteos == id);
            _context.Cumbretimoteos.Remove(cumbretimoteos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CumbretimoteosExists(int id)
        {
            return _context.Cumbretimoteos.Any(e => e.CodigoCumbreTimoteos == id);
        }
    }
}
