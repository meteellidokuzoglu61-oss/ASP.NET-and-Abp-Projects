using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OgrenciApp.Models;
using OgrenciApp.Data;
using System.IO;
using System;
using System.Linq;

namespace OgrenciApp.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly OgrenciContext _context;
        private readonly IWebHostEnvironment _env;

        public OgrenciController(OgrenciContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: /Ogrenci/OgretmenIndex
        public IActionResult OgretmenIndex()
        {
            var ogretmenler = _context.Ogretmenler.ToList();
            return View(ogretmenler);
        }

        // GET: /Ogrenci/OgretmenCreate
        public IActionResult OgretmenCreate()
        {
            return View();
        }

        // POST: /Ogrenci/OgretmenCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OgretmenCreate(Ogretmen model, IFormFile? Foto)
        {
            if (ModelState.IsValid)
            {
                string? fotoPath = null;

                if (Foto != null)
                {
                    var uploads = Path.Combine(_env.WebRootPath, "images/ogretmen");
                    if (!Directory.Exists(uploads))
                        Directory.CreateDirectory(uploads);

                    var filePath = Path.Combine(uploads, Foto.FileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await Foto.CopyToAsync(stream);

                    fotoPath = "/images/ogretmen/" + Foto.FileName;
                }

                model.Ogretmen_Fotografi = fotoPath ?? "/images/ogretmen/default.png";
                _context.Ogretmenler.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("OgretmenIndex"); // Listeye yönlendir
            }

            return View(model);
        }

        // GET: /Ogrenci/OgretmenEdit/5
public IActionResult OgretmenEdit(int id)
        {
            var ogretmen = _context.Ogretmenler.Find(id);
            if (ogretmen == null) return NotFound();
            return View(ogretmen);
        }

        // POST: /Ogrenci/OgretmenEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OgretmenEdit(Ogretmen model, IFormFile? Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto != null)
                {
                    var uploads = Path.Combine(_env.WebRootPath, "images/ogretmen");
                    if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
                    var filePath = Path.Combine(uploads, Foto.FileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await Foto.CopyToAsync(stream);
                    model.Ogretmen_Fotografi = "/images/ogretmen/" + Foto.FileName;
                }

                _context.Ogretmenler.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("OgretmenIndex");
            }
            return View(model);
        }

        // GET: /Ogrenci/OgretmenDelete/5
        public IActionResult OgretmenDelete(int id)
        {
            var ogretmen = _context.Ogretmenler.Find(id);
            if (ogretmen == null) return NotFound();
            return View(ogretmen);
        }

        // POST: /Ogrenci/OgretmenDelete/5
        [HttpPost, ActionName("OgretmenDelete")]
        [ValidateAntiForgeryToken]
        public IActionResult OgretmenDeleteConfirmed(int id)
        {
            var ogretmen = _context.Ogretmenler.Find(id);
            if (ogretmen != null)
            {
                _context.Ogretmenler.Remove(ogretmen);
                _context.SaveChanges();
            }
            return RedirectToAction("OgretmenIndex");
        }
        public IActionResult OgretmenDetails(int id)
        {
            var ogretmen = _context.Ogretmenler.FirstOrDefault(o => o.Id == id);
            if (ogretmen == null) return NotFound();
            return View(ogretmen);
        }





        [HttpGet]
        public IActionResult Create() => View();
        
        

        // GET: /Ogrenci/Index
        public IActionResult Index(string search, string sinif, string cinsiyet)
        {
            var query = _context.Ogrenciler.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(o => o.Ogrenci_AdiSoyadi.Contains(search));

            if (!string.IsNullOrEmpty(sinif))
                query = query.Where(o => o.Ogrenci_Sinifi == sinif);

            if (!string.IsNullOrEmpty(cinsiyet))
                query = query.Where(o => o.Ogrenci_Cinsiyeti == cinsiyet);

            var ogrenciler = query.ToList();
            return View(ogrenciler);
        }

        // GET: /Ogrenci/Create
        [HttpGet]
        public IActionResult CreateGET()
        {
            return View();
        }

        // POST: /Ogrenci/Create
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model, IFormFile? Fotoğraf)
        {
            if (ModelState.IsValid)
            {
                string? fotoPath = null;

                if (Fotoğraf != null)
                {
                    var uploads = Path.Combine(_env.WebRootPath, "images");
                    if (!Directory.Exists(uploads))
                        Directory.CreateDirectory(uploads);

                    var filePath = Path.Combine(uploads, Fotoğraf.FileName);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await Fotoğraf.CopyToAsync(stream);

                    fotoPath = "/images/" + Fotoğraf.FileName;
                }

                model.Ogrenci_Fotografi = fotoPath;
                _context.Ogrenciler.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Ogrenci/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci == null)
                return NotFound();

            return View(ogrenci);
        }

        // POST: /Ogrenci/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ogrenci ogrenci, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto != null && Foto.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    if (!Directory.Exists(uploads))
                        Directory.CreateDirectory(uploads);

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Foto.FileName);
                    var filePath = Path.Combine(uploads, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Foto.CopyTo(stream);
                    }

                    ogrenci.Ogrenci_Fotografi = "/uploads/" + fileName;
                }

                _context.Ogrenciler.Update(ogrenci);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        // GET: /Ogrenci/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci == null)
                return NotFound();

            return View(ogrenci);
        }

        // POST: /Ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ogrenci = _context.Ogrenciler.Find(id);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: /Ogrenci/Details/5
        public IActionResult Details(int id)
        {
            var ogrenci = _context.Ogrenciler.FirstOrDefault(o => o.Ogrenci_ID == id);
            if (ogrenci == null)
                return NotFound();

            ViewBag.Cinsiyet = ogrenci.Ogrenci_Cinsiyeti ?? "Bilinmiyor";
            return View(ogrenci);
        }
    }
}
