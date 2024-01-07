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
    public class VentaCamionetasController : Controller
    {
        private readonly ConcesionariaDatabaseContext _context;

        public VentaCamionetasController(ConcesionariaDatabaseContext context)
        {
            _context = context;
        }

        // GET: VentaCamionetas
        public async Task<IActionResult> Index()
        {
            List<VentaCamioneta> lst = new List<VentaCamioneta>();
            using (_context)
            {
                lst = (from d in _context.VentaCamioneta
                       select new VentaCamioneta
                       {
                           Id = d.Id,
                           camioneta = _context.Camionetas.SingleOrDefault(a => a.ID == d.Id),
                           cliente = _context.Persona.SingleOrDefault(a => a.PersonaId == d.IdCliente)
                       }).ToList();
            }

            ViewBag.items = lst;
            return View();
        }

        
        // GET: VentaCamionetas/Create
        public IActionResult Create()
        {
            List<Camioneta> lst = new List<Camioneta>();
            List<Persona> lstPersona = new List<Persona>();
            using (_context)
            {
                lst = (from d in _context.Camionetas
                       select new Camioneta
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

        // POST: VentaCamionetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaCamioneta,IdCliente,Id")] VentaCamioneta ventaCamioneta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaCamioneta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventaCamioneta);
        }

     
        private bool VentaCamionetaExists(int id)
        {
            return _context.VentaCamioneta.Any(e => e.IdVentaCamioneta == id);
        }
    }
}
