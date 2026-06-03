using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OgrenciApp.Data;
using OgrenciApp.Models;
using System.Linq;
using WebApplication1.Models;

namespace OgrenciApp.Controllers
{
    [Authorize] // Sadece giriş yapmış kullanıcılar erişebilir
    public class SinavController : Controller
    {
        private readonly OgrenciContext _context;

        public SinavController(OgrenciContext context)
        {
            _context = context;
        }

        // GET: Sınav Takvimi
        public IActionResult Index()
        {
            var sinavlar = _context.Sinavlar
                .OrderBy(x => x.Tarih)
                .ToList();

            return View(sinavlar);
        }

        // GET: Yeni Sınav Ekle
        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yeni Sınav Ekle
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Teacher")]
        public IActionResult Create(Sinav model)
        {
            if (ModelState.IsValid)
            {
                _context.Sinavlar.Add(model);
                _context.SaveChanges();

                TempData["Success"] = "Sınav başarıyla eklendi!";
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
