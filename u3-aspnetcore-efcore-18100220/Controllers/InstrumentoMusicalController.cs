using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using u3_aspnetcore_efcore_18100220.Models;

namespace u3_aspnetcore_efcore_18100220.Controllers {
    public class InstrumentoMusicalController : Controller {

        private readonly TiendaDeInstrumentosContext db;

        public InstrumentoMusicalController(TiendaDeInstrumentosContext context) {
            db = context;
        }

        public IActionResult Index() {
            
            var listadoRegistros = db.InstrumentoMusicals.ToList();
            return View("ListadoRegistros", listadoRegistros);
        }

        public IActionResult ListadoRegistros() {
            var listadoRegistros = db.InstrumentoMusicals.ToList();
            return View(listadoRegistros);
        }


        public IActionResult AgregarRegistro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarRegistro(InstrumentoMusical instrumento) {
            if (ModelState.IsValid) {
                var count = db.InstrumentoMusicals.Count();
                instrumento.IdInstrumento = count + 1;
                db.Add(instrumento);
                db.SaveChanges();
            }
            return View("RegistroExitoso", instrumento);
        }
        public async Task<IActionResult> EditarRegistro(int? id) {
            if (id == null) {
                return NotFound();
            }

            var instrumento = await db.InstrumentoMusicals.FindAsync(id);
            if (instrumento == null) {
                return NotFound();
            }
            return View(instrumento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarRegistro(int id, InstrumentoMusical instrumento) {
            if (id != instrumento.IdInstrumento) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    db.Update(instrumento);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!InstrumentoMusicalExist(instrumento.IdInstrumento)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(instrumento);
        }

        private bool InstrumentoMusicalExist(int id) {
            return db.InstrumentoMusicals.Any(e => e.IdInstrumento == id);
        }

        public async Task<IActionResult> EliminarRegistro(int? id) {
            if (id == null) {
                return NotFound();
            }

            var instrumento = await db.InstrumentoMusicals
            .FirstOrDefaultAsync(m => m.IdInstrumento == id);

            if (instrumento == null) {
                return NotFound();
            }

            return View("EliminarRegistro", instrumento);
        }

        [HttpPost]
        public IActionResult ConfirmacionEliminarInstrumento(int idInstrumento) {
            var instrumento = db.InstrumentoMusicals.Find(idInstrumento);

            if (instrumento == null) {
                return NotFound();
            }

            db.Remove(instrumento);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CargarRegistros() {
            InstrumentoMusical instrumento1 = new InstrumentoMusical() {
                Nombre = "violin",
                IdTipo = 1
            };
            var count = db.InstrumentoMusicals.Count();
            instrumento1.IdInstrumento = ++count;
            db.Add(instrumento1);

            InstrumentoMusical instrumento2 = new InstrumentoMusical() {
                Nombre = "arpa",
                IdTipo = 1
            };
            instrumento2.IdInstrumento = ++count;
            db.Add(instrumento2);

            InstrumentoMusical instrumento3 = new InstrumentoMusical() {
                Nombre = "banjo",
                IdTipo = 1
            };
            instrumento3.IdInstrumento = ++count;
            db.Add(instrumento3);

            InstrumentoMusical instrumento4 = new InstrumentoMusical() {
                Nombre = "bombo",
                IdTipo = 2
            };
            instrumento4.IdInstrumento = ++count;
            db.Add(instrumento4);

            InstrumentoMusical instrumento5 = new InstrumentoMusical() {
                Nombre = "claves",
                IdTipo = 2
            };
            instrumento5.IdInstrumento = ++count;
            db.Add(instrumento5);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
