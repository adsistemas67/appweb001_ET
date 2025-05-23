using appweb001.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace appweb001.Controllers
{
    public class ContactoController : Controller
    {
        private readonly ContextoDeDatos _contextodatos;

        public ContactoController(ContextoDeDatos contextodatos)
        {
            this._contextodatos = contextodatos;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var consulta = await _contextodatos.contactos.ToListAsync();
                return View(consulta);
            }
            catch (Exception ex)
            {
                // En lugar de retornar View("Error") sin modelo
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    ErrorMessage = "Error al cargar los contactos."
                };
                return View("Error", errorViewModel);
            }
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Contactos contacto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contextodatos.contactos.Add(contacto);
                    await _contextodatos.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(contacto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al guardar el contacto");
                return View(contacto);
            }
        }
    }
}