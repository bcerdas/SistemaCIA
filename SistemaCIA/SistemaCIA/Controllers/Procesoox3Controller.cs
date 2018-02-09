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
    public class Procesoox3Controller : Controller
    {
        private readonly SistemaCIADBContext _context;

        public Procesoox3Controller(SistemaCIADBContext context)
        {
            _context = context;
        }

        // GET: Procesoox3
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procesoox3.ToListAsync());
        }

        // GET: Procesoox3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesoox3 = await _context.Procesoox3
                .SingleOrDefaultAsync(m => m.CodigoProcesoOx3 == id);
            if (procesoox3 == null)
            {
                return NotFound();
            }

            return View(procesoox3);
        }

        // GET: Procesoox3/Create
        public IActionResult AgregarProcesoX3()
        {
            return View();
        }

        // POST: Procesoox3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarProcesoX3(Procesoox3 procesoox3, string celulas)
        {
            if (ModelState.IsValid)
            {
                var separados = celulas.Split("/");
                procesoox3.CantOrando = 0;
                procesoox3.TotalConvertidos = 0;

                _context.Add(procesoox3);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    var procesoOx3Agregado = _context.Procesoox3.LastOrDefault();

                    for (int i = 0; i < separados.Length; i++)
                    {
                        var procesoOx3Celula = new Procesox3celulas()
                        {
                            CodigoCelula = separados[i],
                            CantidadPersonasOrando = 0,
                            CodigoProcesoX3 = procesoOx3Agregado.CodigoProcesoOx3
                        };

                        _context.Procesox3celulas.Add(procesoOx3Celula);

                    }

                    var result2 = await _context.SaveChangesAsync();
                    if (result2 > 0)
                    {
                        return RedirectToAction(nameof(Index));//Hay que cambiarlo
                    }
                }
                
            }
            return View(procesoox3);
        }

        // GET: Procesoox3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesoox3 = await _context.Procesoox3.SingleOrDefaultAsync(m => m.CodigoProcesoOx3 == id);
            if (procesoox3 == null)
            {
                return NotFound();
            }
            return View(procesoox3);
        }

        // POST: Procesoox3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoProcesoOx3,FechaInicio,FechaFinal,CantOrando,TotalConvertidos")] Procesoox3 procesoox3)
        {
            if (id != procesoox3.CodigoProcesoOx3)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesoox3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Procesoox3Exists(procesoox3.CodigoProcesoOx3))
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
            return View(procesoox3);
        }

        // GET: Procesoox3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesoox3 = await _context.Procesoox3
                .SingleOrDefaultAsync(m => m.CodigoProcesoOx3 == id);
            if (procesoox3 == null)
            {
                return NotFound();
            }

            return View(procesoox3);
        }

        // POST: Procesoox3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procesoox3 = await _context.Procesoox3.SingleOrDefaultAsync(m => m.CodigoProcesoOx3 == id);
            _context.Procesoox3.Remove(procesoox3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Procesoox3Exists(int id)
        {
            return _context.Procesoox3.Any(e => e.CodigoProcesoOx3 == id);
        }
    }
}
