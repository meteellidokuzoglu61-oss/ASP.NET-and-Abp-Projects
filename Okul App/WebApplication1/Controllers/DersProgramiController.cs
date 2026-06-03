using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OgrenciApp.Data;
using OgrenciApp.Models;
using System.Linq;

public class DersProgramiController : Controller
{
    private readonly OgrenciContext _context;

    public DersProgramiController(OgrenciContext context)
    {
        _context = context;
    }

    // Dersleri sinifId'ye göre listeleme
    public IActionResult Index(int sinifId)
    {
        // Veritabanından o sınıfın derslerini çekiyoruz
        var dersler = _context.DersProgramilari
            .Include(d => d.Sinif)
            .Where(d => d.SinifId == sinifId)
            .ToList();

        if (!dersler.Any())
            return NotFound("Bu sınıf için ders programı bulunmamaktadır.");

        return View(dersler); // View'a liste gönderiyoruz
    }

}
