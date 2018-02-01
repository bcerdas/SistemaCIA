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

        public ActionResult MatriculaAcademia(int? id) {

            if (id == null)
            {
                return NotFound();
            }

            var academias = _context.Academias.SingleOrDefault(x => x.CodigoAcademias == id);

            ViewBag.nombreAcademias = academias.Nombre;
            ViewBag.fechaAcademias = academias.Fecha.ToShortDateString();

            var matriculas = _context.Academiasmatriculas
                
                .Include(n => n.CodigoNivelNavigation)//Niveles
                
                .Where(x => x.CodigoAcademias == id).ToList();

            var matriculados =  new List<MatriculadosAcademiasModel>();
            
            foreach (var item in matriculas)
            {
                var persona = _context.Personas.Include(l => l.LiderNavigation)//Lideres 
                    .Include(a => a.NivelAcademiasNavigation)//Academias
                    .SingleOrDefault(x => x.CodigoPersona == item.CodigoPersona);
                var matriculado = new MatriculadosAcademiasModel() {
                    CodigoAcademiaMatricula = item.CodigoAcademiaMatricula,
                    Nombre = persona.Nombre,
                    Apellido1 = persona.Apellido1,
                    Apellido2 = persona.Apellido2,
                    Lider = persona.LiderNavigation.Nombre + " " + persona.LiderNavigation.Apellido1,
                    NivelAcademias = persona.NivelAcademiasNavigation.Nombre,
                    Abono = item.Abono,
                    Saldo = item.Saldo,
                    Becado = item.Becado,
                    NivelMatriculado = item.CodigoNivelNavigation.Nombre
                };

                matriculados.Add(matriculado);
                
            }

            ViewBag.Niveles = new SelectList(_context.Academiasniveles.Include(m => m.CodigoNivelNavigation).Where(x => x.CodigoAcademias == id).ToList(), "CodigoNivel", "CodigoNivelNavigation.Nombre");
            
            MatriculaAcademiaModel matriculaAcademias = new MatriculaAcademiaModel();
            matriculaAcademias.Matriculados = matriculados;

            return View(matriculaAcademias);
        }

        [HttpPost]
        public async Task<IActionResult> MatriculaAcademia(MatriculaAcademiaModel matricula, int? id)
        {
            if (ModelState.IsValid)
            {

                if (id == null)
                {
                    NotFound();
                }

                var pepe = matricula.Observaciones;
                var pepe2 = matricula.Becado;
                var becado = 0;
                var saldo = 6000;

                if (matricula.Becado)
                {
                    becado = 1;
                    saldo = 3000;
                }

                Academiasmatriculas matriculado = new Academiasmatriculas()
                {
                    CodigoAcademias = (int)id,
                    CodigoNivel = matricula.Niveles,
                    CodigoPersona = matricula.CodigoPersona,
                    Abono = matricula.Abono,
                    Becado = becado,
                    Saldo = saldo - matricula.Abono,
                    Observaciones = matricula.Observaciones
                };
                _context.Academiasmatriculas.Add(matriculado);
                await _context.SaveChangesAsync();

                var ultimoMatriculado = _context.Academiasmatriculas.LastOrDefault();

                if (ultimoMatriculado.Abono > 0)
                {
                    Academiasabono abonoMatriculado = new Academiasabono()
                    {
                        CodigoAcademiasMatricula = ultimoMatriculado.CodigoAcademiaMatricula,
                        Fecha = DateTime.Now,
                        Abono = ultimoMatriculado.Abono,
                    };

                    _context.Academiasabono.Add(abonoMatriculado);
                    await _context.SaveChangesAsync();
                }
                
            }

            return RedirectToAction("MatriculaAcademia", new { id = id });
        }

  
        public ActionResult AbonarMatriculado(int? id, int? abono)
        {
            if (id == null || abono == null)
            {
                NotFound();
            }

            var matricula = _context.Academiasmatriculas.SingleOrDefault(x => x.CodigoAcademiaMatricula == id);

            if (abono > matricula.Saldo)
            {
                ViewBag.msj = "No se puede hacer el abono, la cantidad excede al saldo";
            }
            else
            {
                Academiasabono nuevoAbono = new Academiasabono()
                {
                    CodigoAcademiasMatricula = (int)id,
                    Fecha = DateTime.Now,
                    Abono = (int)abono
                };

                _context.Academiasabono.Add(nuevoAbono);
                _context.SaveChanges();

                matricula.Abono = matricula.Abono + (int)abono;
                matricula.Saldo = matricula.Saldo - (int)abono;

                _context.Academiasmatriculas.Update(matricula);
                _context.SaveChanges();
            }

            return RedirectToAction("MatriculaAcademia", new { id = matricula.CodigoAcademias });
        }

        public ActionResult EliminarMatriculado(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            var abonos = _context.Academiasabono.Where(x => x.CodigoAcademiasMatricula == id);
            if (abonos.Count() > 0)
            {
                _context.RemoveRange(abonos);
                _context.SaveChanges();
            }

            var matriculado = _context.Academiasmatriculas.SingleOrDefault(x => x.CodigoAcademiaMatricula == id);
            _context.Remove(matriculado);
            _context.SaveChanges();         
            
            return RedirectToAction("MatriculaAcademia",new {id = matriculado.CodigoAcademias });
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
            objeto.Fecha = DateTime.Now;
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
