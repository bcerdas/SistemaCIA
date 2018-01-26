using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCIA.Models.ContextDb;
using SistemaCIA.Models.Encounters;
using SistemaCIA.Models.Login;
using SistemaCIA.Models.Session;

namespace SistemaCIA.Controllers
{

    public class EncuentrosController : Controller
    {
        private readonly SistemaCIADBContext _context;

        public EncuentrosController(SistemaCIADBContext context)
        {
            _context = context;
        }

        // GET: GestionarEncuentros
        [PermisoAttribute(Permiso = RolesPermisos.Consolidacion)]
        public async Task<IActionResult> GestionarEncuentros()
        {
            var sistemaCIADBContext = _context.Encuentros.Include(e => e.AsistenteCocinaNavigation).Include(e => e.AsistenteNavigation).Include(e => e.CocinaNavigation).Include(e => e.CoordinadorNavigation).Include(e => e.DecoracionNavigation).Include(e => e.FinanzasNavigation).Include(e => e.GuiaH1Navigation).Include(e => e.GuiaH2Navigation).Include(e => e.GuiaM1Navigation).Include(e => e.GuiaM2Navigation).Include(e => e.GuiaNavigation).Include(e => e.LogisticaNavigation).Include(e => e.MusicaNavigation).Include(e => e.ServidorNavigation);
            return View(await sistemaCIADBContext.ToListAsync());
        }

        // GET: Encuentros
        [PermisoAttribute(Permiso = RolesPermisos.LiderDeCelula)]
        public async Task<IActionResult> Encuentros()
        {
            var sistemaCIADBContext = _context.Encuentros.Include(e => e.AsistenteCocinaNavigation).Include(e => e.AsistenteNavigation).Include(e => e.CocinaNavigation).Include(e => e.CoordinadorNavigation).Include(e => e.DecoracionNavigation).Include(e => e.FinanzasNavigation).Include(e => e.GuiaH1Navigation).Include(e => e.GuiaH2Navigation).Include(e => e.GuiaM1Navigation).Include(e => e.GuiaM2Navigation).Include(e => e.GuiaNavigation).Include(e => e.LogisticaNavigation).Include(e => e.MusicaNavigation).Include(e => e.ServidorNavigation);
            return View(await sistemaCIADBContext.Where(x => x.Estado == "Disponible").ToListAsync());
        }

        // GET: Encuentros/Details/5
        [PermisoAttribute(Permiso = RolesPermisos.Consolidacion)]
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
        [PermisoAttribute(Permiso = RolesPermisos.LiderDeCelula)]
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

        [PermisoAttribute(Permiso = RolesPermisos.Consolidacion)]
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
            ViewData["GuiaH1"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
                (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
                .Where(x => x.CodigoRol == 2), "CodigoPersona", "CodigoPersona", encuentro.GuiaH1);
            ViewData["GuiaH2"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
                (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
                .Where(x => x.CodigoRol == 2), "CodigoPersona", "CodigoPersona", encuentro.GuiaH2);
            ViewData["GuiaM1"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
                (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
                .Where(x => x.CodigoRol == 2), "CodigoPersona", "CodigoPersona", encuentro.GuiaM1);
            ViewData["GuiaM2"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
                (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
                .Where(x => x.CodigoRol == 2), "CodigoPersona", "CodigoPersona", encuentro.GuiaM2);
            ViewData["Guia"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
                (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
                .Where(x => x.CodigoRol == 2), "CodigoPersona", "CodigoPersona", encuentro.Guia);
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

        [PermisoAttribute(Permiso = RolesPermisos.Consolidacion)]
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
        //[PermisoAttribute(Permiso = RolesPermisos.LiderDeCelula)]
        public IActionResult AgregarEncuentrista(int? id)
        {
            //ViewData["Lider"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
            //    (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
            //    .Where(x => x.CodigoRol == 2), "CodigoPersona", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarEncuentrista(int? id, Personas personas)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return NotFound();
                }

                personas.FechaIngreso = DateTime.Now.Date;
                personas.NivelAcademias = 14;
                personas.CumbreTimoteos = false;
                personas.CumbreLideres = false;
                personas.Lider = SessionHelper.ObtenerCodigoPersona;
                _context.Add(personas);

                Encuentrosmatricula matricula = new Encuentrosmatricula()
                {
                    CodigoEncuentro = (int)id,
                    CodigoPersona = personas.CodigoPersona,
                    Abono = 0,
                    Saldo = 35000
                };

                _context.Add(matricula);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Encuentros));
            }

            ViewData["Lider"] = new SelectList(_context.Personas.Join(_context.Personasroles, p => p.CodigoPersona, r => r.CodigoPersona,
                (p, r) => new { Nombre = p.Nombre, CodigoRol = r.CodigoRol, CodigoPersona = p.CodigoPersona })
                .Where(x => x.CodigoRol == 2), "CodigoPersona", "Nombre", personas.Lider);

            return View(personas);
        }

        // GET: Encuentros/Edit/5
        [PermisoAttribute(Permiso = RolesPermisos.Consolidacion)]
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

        public IActionResult Encuentristas(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lider = SessionHelper.ObtenerCodigoPersona;
            var personas = _context.Personas.Include(p => p.CodigoAreaNavigation).Include(p => p.CodigoMinisterioNavigation).Include(p => p.NivelAcademiasNavigation).Where(x => x.Lider == lider).ToList();

            var matriculaEncuentro = _context.Encuentrosmatricula.Include(e => e.CodigoEncuentroNavigation).Where(x => x.CodigoEncuentro == id).ToList();
            List<EncuentristasModel> encuentristas = new List<EncuentristasModel>();

            foreach (var item in matriculaEncuentro)
            {
                foreach (var item2 in personas)
                {
                    if (item.CodigoPersona == item2.CodigoPersona)
                    {
                        var nuevoEncuentrista = new EncuentristasModel()
                        {
                            CodigoEncuentro = item.CodigoEncuentro,
                            CodigoPersona = item2.CodigoPersona,
                            Nombre = item2.Nombre,
                            Apellido1 = item2.Apellido1,
                            Apellido2 = item2.Apellido2,
                            NombreCompletoMadre = item2.NombreCompletoMadre,
                            NombreCompletoPadre = item2.NombreCompletoPadre,
                            NombreCompletoConyuge = item2.NombreCompletoConyuge,
                            NombreCompletoEncargado = item2.NombreCompletoEncargado,
                            NombreEncuentro = item.CodigoEncuentroNavigation.Nombre,
                            Telefono = item2.Telefono,
                            TelefonoPadre = item2.TelefonoPadre,
                            TelefonoMadre = item2.TelefonoMadre,
                            TelefonoConyuge = item2.TelefonoConyuge,
                            TelefonoEncargado = item2.TelefonoEncargado,
                            Direccion = item2.Direccion,
                            FechaDeNacimiento = item2.FechaDeNacimiento,
                            ParentescoEncargado = item2.ParentescoEncargado,
                            Sexo = item2.Sexo,
                            Lider = item2.Lider,
                            FechaFinal = item.CodigoEncuentroNavigation.FechaFinal,
                            FechaInicio = item.CodigoEncuentroNavigation.FechaInicio
                        };

                        encuentristas.Add(nuevoEncuentrista);
                    }
                }
            }

            return View(encuentristas);
        }

        public IActionResult GestionarEncuentristas(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var matriculaEncuentro = _context.Encuentrosmatricula.Where(x => x.CodigoEncuentro == id);
            var personas = _context.Personas.Where(x => x.NivelAcademias == 14);

            List<ConsolidacionEncuentristasModel> encuentristas = new List<ConsolidacionEncuentristasModel>();

            foreach (var item in matriculaEncuentro)
            {
                foreach (var item2 in personas)
                {
                    if (item.CodigoPersona == item2.CodigoPersona)
                    {
                        var nuevoEncuentrista = new ConsolidacionEncuentristasModel()
                        {
                            CodigoPersona = item2.CodigoPersona,
                            CodigoEncuentro = item.CodigoEncuentro,
                            Nombre = item2.Nombre,
                            Apellido1 = item2.Apellido1,
                            Apellido2 = item2.Apellido2,
                            Estado = item.Estado,
                            Observaciones = item.Observaciones,
                            Saldo = item.Saldo,
                            Abono = item.Abono,
                            Lider = item2.Lider,
                            Sexo = item2.Sexo,
                            Telefono = item2.Telefono,
                            FechaDeNacimiento = item2.FechaDeNacimiento,
                            Guia = item.Guia
                        };

                        encuentristas.Add(nuevoEncuentrista);
                    }
                }
            }

            List<SelectListItem> guias = new List<SelectListItem>();

            var encuentro = _context.Encuentros.Include(e => e.GuiaH1Navigation).Include(e => e.GuiaH2Navigation)
                .Include(e => e.GuiaM1Navigation).Include(e => e.GuiaM2Navigation).Include(e => e.GuiaNavigation).
                FirstOrDefault(x => x.CodigoEncuentro == id);

            guias.Add(new SelectListItem() { Text = "Asignar", Value = null });
            guias.Add(new SelectListItem() { Text = encuentro.GuiaH1Navigation.Nombre, Value = encuentro.GuiaH1 });
            guias.Add(new SelectListItem() { Text = encuentro.GuiaH2Navigation.Nombre, Value = encuentro.GuiaH2 });
            guias.Add(new SelectListItem() { Text = encuentro.GuiaM1Navigation.Nombre, Value = encuentro.GuiaM1 });
            guias.Add(new SelectListItem() { Text = encuentro.GuiaM2Navigation.Nombre, Value = encuentro.GuiaM2 });
            ViewBag.Guias = guias;


            return View(encuentristas);
        }


        public ActionResult AsignarGuia(string cod)
        {

            if (string.IsNullOrEmpty(cod))
            {
                return NotFound();
            }

            string[] separadas;

            separadas = cod.Split('/');

            var codigoGuia = separadas[0];
            var codigoPersona = separadas[1];
            var codigoEncuentro = Convert.ToInt32(separadas[2]);

            if (codigoGuia == "Asignar")
            {
                return RedirectToAction(nameof(GestionarEncuentristas));
                Response.Redirect("~/Views/Encuentros/GestionarEncuentristas.cshtml");
            }

            var nuevoAsignado = _context.Encuentrosmatricula.SingleOrDefault(x => x.CodigoEncuentro == codigoEncuentro && x.CodigoPersona == codigoPersona);
            nuevoAsignado.Guia = codigoGuia;
            _context.Encuentrosmatricula.Update(nuevoAsignado);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction("GestionarEncuentristas");
            }

            return View();
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



        private bool EncuentrosExists(int id)
        {
            return _context.Encuentros.Any(e => e.CodigoEncuentro == id);
        }
    }
}
