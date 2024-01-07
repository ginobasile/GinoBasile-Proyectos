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
    public class MotoController : Controller
    {
        private readonly ConcesionariaDatabaseContext _context;
        private IWebHostEnvironment _environment;

        public MotoController(ConcesionariaDatabaseContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Moto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Motos.ToListAsync());
        }

        // GET: Moto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // GET: Moto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Moto moto)
        {
           
            if (moto.PhotoAvatar != null && moto.PhotoAvatar.Length > 0)
            {
                moto.ImageMimeType = moto.PhotoAvatar.ContentType;
                moto.ImageName = Path.GetFileName(moto.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    moto.PhotoAvatar.CopyTo(memoryStream);
                    moto.PhotoFile = memoryStream.ToArray();
                }
                _context.Add(moto);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Moto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }
            return View(moto);
        }

        // POST: Moto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tipo,ID,Marca,Modelo,EsUsado,CantKm,ImageMimeType,ImageName,PhotoFile,Anio,Precio")] Moto moto)
        {
            if (id != moto.ID)
            {
                return NotFound();
            }
            try
            {
                _context.Update(moto);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoExists(moto.ID))
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

        // GET: Moto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (moto == null)
            {
                return NotFound();
            }

            return View(moto);
        }

        // POST: Moto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetImage(int id)
        {
            Moto requestedVehiculo = _context.Motos.SingleOrDefault(c => c.ID == id);
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
        private bool MotoExists(int id)
        {
            return _context.Motos.Any(e => e.ID == id);
        }
    }
}
