using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCConcesionaria.Context;
using MVCConcesionaria.Models;

namespace MVCConcesionaria.Controllers
{
    public class VentaMotoesController : Controller
    {
        private readonly ConcesionariaDatabaseContext _context;

        public VentaMotoesController(ConcesionariaDatabaseContext context)
        {
            _context = context;
        }

        // GET: VentaMotoes
        public async Task<IActionResult> Index()
        {
            List<VentaMoto> lst = new List<VentaMoto>();
            using (_context)
            {
                lst = (from d in _context.VentaMoto
                       select new VentaMoto
                       {
                           Id = d.Id,
                           moto = _context.Motos.SingleOrDefault(a => a.ID == d.Id),
                           cliente = _context.Persona.SingleOrDefault(a => a.PersonaId == d.IdCliente)
                       }).ToList();
            }

            ViewBag.items = lst;
            return View();
        }

        // GET: VentaMotoes/Create
        public IActionResult Create()
        {
            List<Moto> lst = new List<Moto>();
            List<Persona> lstPersona = new List<Persona>();
            using (_context)
            {
                lst = (from d in _context.Motos
                       select new Moto
                       {
                           ID = d.ID,
                           Marca = d.Marca,
                           Modelo = d.Modelo,
                           Precio = d.Precio,
                           Anio = d.Anio
                       }).ToList();
                lstPersona = (from d in _context.Persona
                              select new Persona
                              {
                                  PersonaId = d.PersonaId,
                                  PersonaDNI = d.PersonaDNI,
                                  Apellido = d.Apellido,
                                  Nombre = d.Nombre
                              }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.datosVehiculo,
                    Value = d.ID.ToString(),
                    Selected = false
                };
            });
            List<SelectListItem> personas = lstPersona.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.datosPersona,
                    Value = d.PersonaId.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;
            ViewBag.personas = personas;
            return View();
        }

        // POST: VentaMotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaMoto,IdCliente,Id")] VentaMoto ventaMoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaMoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventaMoto);
        }

        private bool VentaMotoExists(int id)
        {
            return _context.VentaMoto.Any(e => e.IdVentaMoto == id);
        }
    }
}
