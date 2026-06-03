using Microsoft.AspNetCore.Mvc;

public class SaatController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Saatler = new List<object>
        {
            new { Ders = "1. Ders", Baslangic = "08:30", Bitis = "09:10" },
            new { Ders = "2. Ders", Baslangic = "09:20", Bitis = "10:00" },
            new { Ders = "3. Ders", Baslangic = "10:10", Bitis = "10:50" },
            new { Ders = "4. Ders", Baslangic = "11:00", Bitis = "11:40" },
            new { Ders = "Öğle Arası", Baslangic = "11:40", Bitis = "12:40" },
            new { Ders = "5. Ders", Baslangic = "12:40", Bitis = "13:20" },
            new { Ders = "6. Ders", Baslangic = "13:30", Bitis = "14:10" },
            new { Ders = "7. Ders", Baslangic = "14:20", Bitis = "15:00" }
        };

        return View();
    }
}
