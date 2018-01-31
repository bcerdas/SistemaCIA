using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCIA.Models.Academias;
using SistemaCIA.Models.ContextDb;

namespace SistemaCIA.Controllers
{
    public class AcademiasController : Controller
    {
        private readonly SistemaCIADBContext _context;

        public AcademiasController(SistemaCIADBContext context)
        {
            _context = context;
        }

        // GET: Academias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Academias.ToListAsync());
        }

        // GET: Academias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academias = await _context.Academias
                .SingleOrDefaultAsync(m => m.CodigoAcademias == id);
            if (academias == null)
            {
                return NotFound();
            }

            return View(academias);
        }

        // GET: Academias/Create
        public IActionResult Create()
        {
            AcademiasNivelesModel objeto = new AcademiasNivelesModel();
            objeto.niveles = _context.Niveles.Where(x => x.Nombre != "Preencuentro").ToList();
            return View(objeto);
        }

        // POST: Academias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AcademiasNivelesModel academias, string parametros)
        {
            if (ModelState.IsValid)
            {
                var separados = parametros.Split("/");
                var cantidad = separados[(separados.Length - 1)];

                var oferta = new Academias() {
                    Nombre = academias.Nombre,
                    Fecha = academias.Fecha,
                    CantNiveles = Convert.ToInt32(cantidad),
                    Asistencia = 0,
                    MontoIngreso = 0,
                    MontoSalida = 0,
                    Total = 0
                };

                _context.Academias.Add(oferta);
                await _context.SaveChangesAsync();

                var ofertaIngresada = _context.Academias.LastOrDefault();

                for (int i = 0; i < (separados.Length-1); i++)
                {
                    var nuevoNivel = new Academiasniveles() {
                        CodigoAcademias = ofertaIngresada.CodigoAcademias,
                        CodigoNivel = Convert.ToInt32(separados[i])
                    };
                    _context.Academiasniveles.Add(nuevoNivel);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
                

                
            }
            return View(academias);
        }

        // GET: Academias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academias = await _context.Academias.SingleOrDefaultAsync(m => m.CodigoAcademias == id);
            if (academias == null)
            {
                return NotFound();
            }
            return View(academias);
        }

        // POST: Academias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoAcademias,Fecha,CantNiveles,Asistencia,MontoIngreso,MontoSalida,Total")] Academias academias)
        {
            if (id != academias.CodigoAcademias)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademiasExists(academias.CodigoAcademias))
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
            return View(academias);
        }

        // GET: Academias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academias = await _context.Academias
                .SingleOrDefaultAsync(m => m.CodigoAcademias == id);
            if (academias == null)
            {
                return NotFound();
            }

            return View(academias);
        }

        // POST: Academias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academias = await _context.Academias.SingleOrDefaultAsync(m => m.CodigoAcademias == id);
            _context.Academias.Remove(academias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademiasExists(int id)
        {
            return _context.Academias.Any(e => e.CodigoAcademias == id);
        }
    }
}
