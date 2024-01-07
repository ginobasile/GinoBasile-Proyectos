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
    public class CamionetaController : Controller
    {
        private readonly ConcesionariaDatabaseContext _context;
        private IWebHostEnvironment _environment;

        public CamionetaController(ConcesionariaDatabaseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Camioneta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Camionetas.ToListAsync());
        }

        // GET: Camioneta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camioneta = await _context.Camionetas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camioneta == null)
            {
                return NotFound();
            }

            return View(camioneta);
        }

        // GET: Camioneta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Camioneta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Camioneta camioneta)
        {
            if (camioneta.PhotoAvatar != null && camioneta.PhotoAvatar.Length > 0)
            {
                camioneta.ImageMimeType = camioneta.PhotoAvatar.ContentType;
                camioneta.ImageName = Path.GetFileName(camioneta.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    camioneta.PhotoAvatar.CopyTo(memoryStream);
                    camioneta.PhotoFile = memoryStream.ToArray();
                }
                _context.Add(camioneta);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Camioneta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camioneta = await _context.Camionetas.FindAsync(id);
            if (camioneta == null)
            {
                return NotFound();
            }
            return View(camioneta);
        }

        // POST: Camioneta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Es4x4,EsDobleCabina,ID,Marca,Modelo,EsUsado,CantKm,ImageMimeType,ImageName,PhotoFile,Anio,Precio")] Camioneta camioneta)
        {
            if (id != camioneta.ID)
            {
                return NotFound();

            }
            try
            {
                _context.Update(camioneta);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamionetaExists(camioneta.ID))
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

        // GET: Camioneta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camioneta = await _context.Camionetas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camioneta == null)
            {
                return NotFound();
            }

            return View(camioneta);
        }

        // POST: Camioneta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camioneta = await _context.Camionetas.FindAsync(id);
            _context.Camionetas.Remove(camioneta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetImage(int id)
        {
            Camioneta requestedVehiculo = _context.Camionetas.SingleOrDefault(a => a.ID == id);
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
        private bool CamionetaExists(int id)
        {
            return _context.Camionetas.Any(e => e.ID == id);
        }
    }
}
