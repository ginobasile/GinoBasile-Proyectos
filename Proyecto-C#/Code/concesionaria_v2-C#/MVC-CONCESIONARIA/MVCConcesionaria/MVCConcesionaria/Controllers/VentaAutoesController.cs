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
    public class VentaAutoesController : Controller
    {
        private readonly ConcesionariaDatabaseContext _context;

        public VentaAutoesController(ConcesionariaDatabaseContext context)
        {
            _context = context;
        }

        // GET: VentaAutoes
        public async Task<IActionResult> Index()
        {
            List<VentaAuto> lst = new List<VentaAuto>();
            using (_context)
            {
                lst = (from d in _context.VentaAuto
                       select new VentaAuto
                       {
                           Id = d.Id,
                           auto = _context.Autos.SingleOrDefault(a => a.ID == d.Id),
                           cliente = _context.Persona.SingleOrDefault(a => a.PersonaId == d.IdCliente)
                       }).ToList();
            }

            ViewBag.items = lst;
            return View();
        }

        // GET: VentaAutoes/Create
        public IActionResult Create()
        {
            List<Auto> lst = new List<Auto>();
            List<Persona> lstPersona = new List<Persona>();
            using (_context)
            {
                lst = (from d in _context.Autos
                       select new Auto
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
            ViewBag.personas= personas;
            return View();
        }

        // POST: VentaAutoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentAuto,IdCliente,Id")] VentaAuto ventaAuto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaAuto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventaAuto);
        }

        
        private bool VentaAutoExists(int id)
        {
            return _context.VentaAuto.Any(e => e.IdVentAuto == id);
        }
    }
}
