using Microsoft.AspNetCore.Mvc;
using OgrenciApp.Data;
using OgrenciApp.Models;
using System.Linq;

using WebApplication1.Models;


namespace OgrenciApp.Controllers
{
    public class EtkinlikController : Controller
    {
        private readonly OgrenciContext _context;

        public EtkinlikController(OgrenciContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var etkinlikler = _context.Etkinlikler
                                       .OrderByDescending(e => e.Tarih)
                                       .ToList();
            return View(etkinlikler);
        }


        public IActionResult Create()
        {
            return View();
        }

        // POST: /Etkinlik/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Etkinlik model)
        {
            if (ModelState.IsValid)
            {
                _context.Etkinlikler.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
