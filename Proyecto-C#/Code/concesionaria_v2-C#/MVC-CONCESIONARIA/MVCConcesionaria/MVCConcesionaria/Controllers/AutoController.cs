using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using MVCConcesionaria.Context;
using MVCConcesionaria.Models;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MVCConcesionaria.Controllers
{
    public class AutoController : Controller
    {
        private readonly ConcesionariaDatabaseContext _context;
        private IWebHostEnvironment _environment;

        public AutoController(ConcesionariaDatabaseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Auto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Autos.ToListAsync());
        }

        // GET: Auto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // GET: Auto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Auto auto)
        {
            if (auto.PhotoAvatar != null && auto.PhotoAvatar.Length > 0)
            {
                auto.ImageMimeType = auto.PhotoAvatar.ContentType;
                auto.ImageName = Path.GetFileName(auto.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                auto.PhotoAvatar.CopyTo(memoryStream);
                auto.PhotoFile = memoryStream.ToArray();
                }
                _context.Add(auto);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Auto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            return View(auto);
        }

        // POST: Auto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CantPuertas,ID,Marca,Modelo,EsUsado,CantKm,ImageMimeType,ImageName,PhotoFile,Anio,Precio")] Auto auto)
        {
            if (id != auto.ID)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(auto);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.ID))
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


        // GET: Auto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // POST: Auto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auto = await _context.Autos.FindAsync(id);
            _context.Autos.Remove(auto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetImage(int id)
        {
            Auto requestedVehiculo = _context.Autos.SingleOrDefault(a => a.ID == id);
            if (requestedVehiculo != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedVehiculo.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedVehiculo.ImageMimeType);
                }
                else
                {
                    if (requestedVehiculo.PhotoFile.Length > 0)
                    {
                        return File(requestedVehiculo.PhotoFile, requestedVehiculo.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }
        private bool AutoExists(int id)
        {
            return _context.Autos.Any(e => e.ID == id);
        }
    }
}
