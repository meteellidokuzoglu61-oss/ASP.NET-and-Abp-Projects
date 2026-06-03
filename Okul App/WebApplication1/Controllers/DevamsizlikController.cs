using Microsoft.AspNetCore.Mvc;
using OgrenciApp.Data;
using OgrenciApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OgrenciApp.Controllers
{
    public class DevamsizlikController : Controller
    {
        private readonly OgrenciContext _context;

        public DevamsizlikController(OgrenciContext context)
        {
            _context = context;
        }

        // Listeleme
        public IActionResult DevamsizlikIndex()
        {
            var devamsizliklar = _context.Devamsizliklar
                                         .OrderByDescending(d => d.Tarih)
                                         .ToList();
            return View(devamsizliklar);
        }

        // GET: Form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kaydet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Devamsizlik devamsizlik)
        {
            if (ModelState.IsValid)
            {
                _context.Devamsizliklar.Add(devamsizlik);
                await _context.SaveChangesAsync();
                return RedirectToAction("DevamsizlikIndex", "Home");
            }

            return View(devamsizlik);
        }

        public IActionResult Edit(int id)
        {
            var devamsizlik = _context.Devamsizliklar.FirstOrDefault(d => d.Id == id);
            if (devamsizlik == null)
            {
                return NotFound();
            }
            return View(devamsizlik);
        }

        // POST: Düzenlemeyi kaydet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Devamsizlik devamsizlik)
        {
            if (!ModelState.IsValid)
            {
                return View(devamsizlik);
            }

            var existing = _context.Devamsizliklar.FirstOrDefault(d => d.Id == devamsizlik.Id);
            if (existing == null)
            {
                return NotFound();
            }

            // Güncellenen alanlar
            existing.Ogrenci_AdSoyad = devamsizlik.Ogrenci_AdSoyad;
            existing.Tarih = devamsizlik.Tarih;
            existing.Durum = devamsizlik.Durum;
            existing.Aciklama = devamsizlik.Aciklama;

            await _context.SaveChangesAsync();

            return RedirectToAction("DevamsizlikIndex", "Home");
        }





    }
}

