using Microsoft.AspNetCore.Mvc;
using OgrenciApp.Data;
using OgrenciApp.Models;
using System.Linq;

public class DuyuruController : Controller
{
    private readonly OgrenciContext _context;

    public DuyuruController(OgrenciContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var list = _context.Duyurular.OrderByDescending(x => x.Tarih).ToList();
        return View(list);
    }


    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Duyuru model)
    {
        if (ModelState.IsValid)
        {
            model.Tarih = DateTime.Now;
            _context.Duyurular.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(model);
    }


    [HttpGet]
    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(Duyuru model, IFormFile? foto)
    {
        if (foto != null)
        {
            // wwwroot/uploads klasörüne kaydet
            var klasorYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(klasorYolu))
                Directory.CreateDirectory(klasorYolu);

            // Dosya adı
            var dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
            var dosyaYolu = Path.Combine(klasorYolu, dosyaAdi);

            using (var stream = new FileStream(dosyaYolu, FileMode.Create))
            {
                foto.CopyTo(stream);
            }

            model.FotoUrl = "/uploads/" + dosyaAdi;
        }

        model.Tarih = DateTime.Now;

        _context.Duyurular.Add(model);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
