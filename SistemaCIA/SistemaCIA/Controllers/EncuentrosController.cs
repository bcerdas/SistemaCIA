using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCIA.Models.ContextDb;
using SistemaCIA.Models.Login;

namespace SistemaCIA.Controllers
{
    public class EncuentrosController : Controller
    {
        private readonly SistemaCIADBContext _context;

        public EncuentrosController(SistemaCIADBContext context)
        {
            _context = context;
        }

        // GET: Encuentros
        public async Task<IActionResult> GestionarEncuentros()
        {
            var sistemaCIADBContext = _context.Encuentros.Include(e => e.AsistenteCocinaNavigation).Include(e => e.AsistenteNavigation).Include(e => e.CocinaNavigation).Include(e => e.CoordinadorNavigation).Include(e => e.DecoracionNavigation).Include(e => e.FinanzasNavigation).Include(e => e.GuiaH1Navigation).Include(e => e.GuiaH2Navigation).Include(e => e.GuiaM1Navigation).Include(e => e.GuiaM2Navigation).Include(e => e.GuiaNavigation).Include(e => e.LogisticaNavigation).Include(e => e.MusicaNavigation).Include(e => e.ServidorNavigation);
            return View(await sistemaCIADBContext.ToListAsync());
        }

        // GET: Encuentros
        public async Task<IActionResult> Encuentros()
        {
            var sistemaCIADBContext = _context.Encuentros.Include(e => e.AsistenteCocinaNavigation).Include(e => e.AsistenteNavigation).Include(e => e.CocinaNavigation).Include(e => e.CoordinadorNavigation).Include(e => e.DecoracionNavigation).Include(e => e.FinanzasNavigation).Include(e => e.GuiaH1Navigation).Include(e => e.GuiaH2Navigation).Include(e => e.GuiaM1Navigation).Include(e => e.GuiaM2Navigation).Include(e => e.GuiaNavigation).Include(e => e.LogisticaNavigation).Include(e => e.MusicaNavigation).Include(e => e.ServidorNavigation);
            return View(await sistemaCIADBContext.Where(x => x.Estado == "Disponible").ToListAsync());
        }

        // GET: Encuentros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuentros = await _context.Encuentros
                .Include(e => e.AsistenteCocinaNavigation)
                .Include(e => e.AsistenteNavigation)
                .Include(e => e.CocinaNavigation)
                .Include(e => e.CoordinadorNavigation)
                .Include(e => e.DecoracionNavigation)
                .Include(e => e.FinanzasNavigation)
                .Include(e => e.GuiaH1Navigation)
                .Include(e => e.GuiaH2Navigation)
                .Include(e => e.GuiaM1Navigation)
                .Include(e => e.GuiaM2Navigation)
                .Include(e => e.GuiaNavigation)
                .Include(e => e.LogisticaNavigation)
                .Include(e => e.MusicaNavigation)
                .Include(e => e.ServidorNavigation)
                .SingleOrDefaultAsync(m => m.CodigoEncuentro == id);
            if (encuentros == null)
            {
                return NotFound();
            }

            return View(encuentros);
        }

        // GET: Encuentros/Create
        public IActionResult CrearEncuentro()
        {          
            return View();
        }

        // POST: Encuentros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEncuentro(Encuentros encuentros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encuentros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GestionarEncuentros));
            }
            
            return View(encuentros);
        }


        public IActionResult AgregarEquipoEnc(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuentro = _context.Encuentros.SingleOrDefault(x => x.CodigoEncuentro == id);

            //Hacer join a los demas

            ViewData["AsistenteCocina"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.AsistenteCocina);
            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.Asistente);
            ViewData["Cocina"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.Cocina);
            ViewData["Coordinador"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.Coordinador);
            ViewData["Decoracion"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.Decoracion);
            ViewData["Finanzas"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.Finanzas);
            ViewData["GuiaH1"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.GuiaH1);
            ViewData["GuiaH2"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.GuiaH2);
            ViewData["GuiaM1"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.GuiaM1);
            ViewData["GuiaM2"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.GuiaM2);
            ViewData["Guia"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.Guia);
            ViewData["Logistica"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.Logistica);
            ViewData["Musica"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
                (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
                .Where(x => x.CodigoRol == 11), "CodigoPersona", "Nombre", encuentro.Musica);
            ViewData["Servidor"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentro.Servidor);

            return View(encuentro);

        //    [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)
        }

        // POST: Encuentros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarEquipoEnc(int id, Encuentros encuentros)
        {
            if (id != encuentros.CodigoEncuentro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Encuentros.Update(encuentros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncuentrosExists(encuentros.CodigoEncuentro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GestionarEncuentros));
            }

            ViewData["AsistenteCocina"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.AsistenteCocina);
            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Asistente);
            ViewData["Cocina"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Cocina);
            ViewData["Coordinador"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Coordinador);
            ViewData["Decoracion"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Decoracion);
            ViewData["Finanzas"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Finanzas);
            ViewData["GuiaH1"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaH1);
            ViewData["GuiaH2"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaH2);
            ViewData["GuiaM1"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaM1);
            ViewData["GuiaM2"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaM2);
            ViewData["Guia"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Guia);
            ViewData["Logistica"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Logistica);
            ViewData["Musica"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Musica);
            ViewData["Servidor"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Servidor);

            return View();
        }


        public IActionResult AgregarFinanzas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuentro = _context.Encuentros.SingleOrDefault(x => x.CodigoEncuentro == id);

            return View(encuentro);
        }

        // POST: Encuentros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarFinanzas(int id, Encuentros encuentros)
        {
            if (id != encuentros.CodigoEncuentro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var encuentro = _context.Encuentros.SingleOrDefault(x => x.CodigoEncuentro == id);
                    encuentro.MontoComida = encuentros.MontoComida;
                    encuentro.MontoDecoracion = encuentros.MontoDecoracion;
                    encuentro.MontoLogistica = encuentros.MontoLogistica;
                    encuentro.MontoServicio = encuentros.MontoServicio;
                    encuentro.MontoTransporte = encuentros.MontoTransporte;
                    encuentro.MontoOtros = encuentros.MontoOtros;

                    var sumaGastos = encuentros.MontoComida + encuentros.MontoDecoracion +
                        encuentros.MontoLogistica + encuentros.MontoServicio + encuentros.MontoTransporte + encuentros.MontoOtros;

                    encuentro.TotalInvertido = sumaGastos;
                    encuentro.TotalRestante = encuentro.TotalDinero - sumaGastos;
                    
                    _context.Encuentros.Update(encuentro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncuentrosExists(encuentros.CodigoEncuentro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GestionarEncuentros));
            }

            return View();
        }


        // GET: Personas/Create
        public IActionResult AgregarEncuentrista()
        {


            ViewData["Lider"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
                (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
                .Where(x => x.CodigoRol == 2), "CodigoPersona", "Nombre");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarEncuentrista(Personas personas)
        {
            if (ModelState.IsValid)
            {
                personas.FechaIngreso = DateTime.Now.Date;
                personas.NivelAcademias = 14;
                personas.CumbreTimoteos = false;
                personas.CumbreLideres = false;
                _context.Add(personas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Encuentros));
            }

            ViewData["Lider"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
                (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
                .Where(x => x.CodigoRol == 2), "CodigoPersona", "Nombre", personas.Lider);

            return View(personas);
        }

        // GET: Encuentros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuentros = await _context.Encuentros.SingleOrDefaultAsync(m => m.CodigoEncuentro == id);
            if (encuentros == null)
            {
                return NotFound();
            }
            ViewData["AsistenteCocina"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.AsistenteCocina);
            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Asistente);
            ViewData["Cocina"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Cocina);
            ViewData["Coordinador"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Coordinador);
            ViewData["Decoracion"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Decoracion);
            ViewData["Finanzas"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Finanzas);
            ViewData["GuiaH1"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaH1);
            ViewData["GuiaH2"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaH2);
            ViewData["GuiaM1"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaM1);
            ViewData["GuiaM2"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaM2);
            ViewData["Guia"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Guia);
            ViewData["Logistica"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Logistica);
            ViewData["Musica"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Musica);
            ViewData["Servidor"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Servidor);
            return View(encuentros);
        }

        // POST: Encuentros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEncuentro,Nombre,Lema,Objetivo,FechaInicio,FechaFinal,Asistencia,Coordinador,Asistente,Logistica,Servidor,Cocina,AsistenteCocina,Musica,GuiaH1,GuiaH2,GuiaM1,GuiaM2,Guia,Finanzas,Decoracion,TotalDinero,TotalInvertido,MontoDecoracion,MontoLogistica,MontoComida,MontoServicio,MontoTransporte,TotalRestante")] Encuentros encuentros)
        {
            if (id != encuentros.CodigoEncuentro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encuentros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncuentrosExists(encuentros.CodigoEncuentro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GestionarEncuentros));
            }
            ViewData["AsistenteCocina"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.AsistenteCocina);
            ViewData["Asistente"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Asistente);
            ViewData["Cocina"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Cocina);
            ViewData["Coordinador"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Coordinador);
            ViewData["Decoracion"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Decoracion);
            ViewData["Finanzas"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Finanzas);
            ViewData["GuiaH1"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaH1);
            ViewData["GuiaH2"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaH2);
            ViewData["GuiaM1"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaM1);
            ViewData["GuiaM2"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.GuiaM2);
            ViewData["Guia"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Guia);
            ViewData["Logistica"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Logistica);
            ViewData["Musica"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Musica);
            ViewData["Servidor"] = new SelectList(_context.Personas, "CodigoPersona", "CodigoPersona", encuentros.Servidor);
            return View(encuentros);
        }

        // GET: Encuentros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuentros = await _context.Encuentros
                .Include(e => e.AsistenteCocinaNavigation)
                .Include(e => e.AsistenteNavigation)
                .Include(e => e.CocinaNavigation)
                .Include(e => e.CoordinadorNavigation)
                .Include(e => e.DecoracionNavigation)
                .Include(e => e.FinanzasNavigation)
                .Include(e => e.GuiaH1Navigation)
                .Include(e => e.GuiaH2Navigation)
                .Include(e => e.GuiaM1Navigation)
                .Include(e => e.GuiaM2Navigation)
                .Include(e => e.GuiaNavigation)
                .Include(e => e.LogisticaNavigation)
                .Include(e => e.MusicaNavigation)
                .Include(e => e.ServidorNavigation)
                .SingleOrDefaultAsync(m => m.CodigoEncuentro == id);
            if (encuentros == null)
            {
                return NotFound();
            }

            return View(encuentros);
        }

        // POST: Encuentros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encuentros = await _context.Encuentros.SingleOrDefaultAsync(m => m.CodigoEncuentro == id);
            _context.Encuentros.Remove(encuentros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(GestionarEncuentros));
        }

        private bool EncuentrosExists(int id)
        {
            return _context.Encuentros.Any(e => e.CodigoEncuentro == id);
        }
    }
}
