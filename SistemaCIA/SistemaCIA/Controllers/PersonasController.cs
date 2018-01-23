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
    public class PersonasController : Controller
    {
        private readonly SistemaCIADBContext _context;

        public PersonasController(SistemaCIADBContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var sistemaCIADBContext = _context.Personas.Include(p => p.CodigoAreaNavigation).Include(p => p.CodigoMinisterioNavigation).Include(p => p.NivelAcademiasNavigation);
            return View(await sistemaCIADBContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas
                .Include(p => p.CodigoAreaNavigation)
                .Include(p => p.CodigoMinisterioNavigation)
                .Include(p => p.NivelAcademiasNavigation)
                .SingleOrDefaultAsync(m => m.CodigoPersona == id);
            if (personas == null)
            {
                return NotFound();
            }

            return View(personas);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["CodigoArea"] = new SelectList(_context.Areasdeministerio, "CodigoArea", "Nombre");
            ViewData["CodigoMinisterio"] = new SelectList(_context.Ministerios, "CodigoMinisterio", "Nombre");
            ViewData["NivelAcademias"] = new SelectList(_context.Niveles, "CodigoNivel", "Nombre");
            return View();
        }

        // POST: Personas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoPersona,CodigoMinisterio,CodigoArea,Nombre,Apellido1,Apellido2,NombreCompletoMadre,TelefonoMadre,NombreCompletoPadre,TelefonoPadre,NombreCompletoConyuge,TelefonoConyuge,NombreCompletoEncargado,TelefonoEncargado,ParentescoEncargado,Telefono,Direccion,FechaIngreso,NivelAcademias,FechaDeNacimiento,CumbreTimoteos,CumbreLideres,Sexo")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoArea"] = new SelectList(_context.Areasdeministerio, "CodigoArea", "Nombre", personas.CodigoArea);
            ViewData["CodigoMinisterio"] = new SelectList(_context.Ministerios, "CodigoMinisterio", "Nombre", personas.CodigoMinisterio);
            ViewData["NivelAcademias"] = new SelectList(_context.Niveles, "CodigoNivel", "Nombre", personas.NivelAcademias);
            return View(personas);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas.SingleOrDefaultAsync(m => m.CodigoPersona == id);
            if (personas == null)
            {
                return NotFound();
            }
            ViewData["CodigoArea"] = new SelectList(_context.Areasdeministerio, "CodigoArea", "Nombre", personas.CodigoArea);
            ViewData["CodigoMinisterio"] = new SelectList(_context.Ministerios, "CodigoMinisterio", "Nombre", personas.CodigoMinisterio);
            ViewData["NivelAcademias"] = new SelectList(_context.Niveles, "CodigoNivel", "Nombre", personas.NivelAcademias);
            return View(personas);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoPersona,CodigoMinisterio,CodigoArea,Nombre,Apellido1,Apellido2,NombreCompletoMadre,TelefonoMadre,NombreCompletoPadre,TelefonoPadre,NombreCompletoConyuge,TelefonoConyuge,NombreCompletoEncargado,TelefonoEncargado,ParentescoEncargado,Telefono,Direccion,FechaIngreso,NivelAcademias,FechaDeNacimiento,CumbreTimoteos,CumbreLideres,Sexo")] Personas personas)
        {
            if (id != personas.CodigoPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasExists(personas.CodigoPersona))
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
            ViewData["CodigoArea"] = new SelectList(_context.Areasdeministerio, "CodigoArea", "Nombre", personas.CodigoArea);
            ViewData["CodigoMinisterio"] = new SelectList(_context.Ministerios, "CodigoMinisterio", "Nombre", personas.CodigoMinisterio);
            ViewData["NivelAcademias"] = new SelectList(_context.Niveles, "CodigoNivel", "Nombre", personas.NivelAcademias);
            return View(personas);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personas = await _context.Personas
                .Include(p => p.CodigoAreaNavigation)
                .Include(p => p.CodigoMinisterioNavigation)
                .Include(p => p.NivelAcademiasNavigation)
                .SingleOrDefaultAsync(m => m.CodigoPersona == id);
            if (personas == null)
            {
                return NotFound();
            }

            return View(personas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personas = await _context.Personas.SingleOrDefaultAsync(m => m.CodigoPersona == id);
            _context.Personas.Remove(personas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonasExists(string id)
        {
            return _context.Personas.Any(e => e.CodigoPersona == id);
        }
    }
}
