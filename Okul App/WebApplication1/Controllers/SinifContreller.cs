using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class SinifController : Controller
{
    public IActionResult Index()
    {
        // Sınıflar listesi
        var siniflar = new List<dynamic>
        {
            new { Ad = "9Amp/A", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "9Amp/B", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "9Amp/C", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "9/D", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "9/E", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "9/F", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "9/G", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "9/H", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "10Amp/A", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "10Amp/B", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "10Amp/C", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "10/D", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "10/E", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "10/F", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "10/G", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "10/H", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "11Amp/A", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "11Amp/B", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "11Amp/C", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "11/D", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "11/E", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "11/F", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "11/G", Rehber = "Ayşe Demir", Telefon = "0505 123 45 01", Blok = "A Blok - 1. Kat", DersProgrami="/DersProgrami/9A.pdf" },
            new { Ad = "11/H", Rehber = "Mehmet Kara", Telefon = "0505 123 45 02", Blok = "A Blok - 2. Kat", DersProgrami="/DersProgrami/9B.pdf" },
            new { Ad = "12/A", Rehber = "Fatma Çelik", Telefon = "0505 123 45 04", Blok = "C Blok - 3. Kat", DersProgrami="/DersProgrami/11C.pdf" },
            new { Ad = "12/B", Rehber = "Mustafa Güneş", Telefon = "0505 123 45 05", Blok = "C Blok - 2. Kat", DersProgrami="/DersProgrami/12B.pdf" }
        };

        // Okul yerleşim planı
        ViewBag.OkulHaritasi = "/images/okul/blok-haritasi.png";

        return View();
    }


    public IActionResult PdfOlustur(string ad)
    {
        var content = $"{ad} Sınıf Listesi\n------------------\nBu alan PDF olarak hazırlanabilir.";

        var bytes = System.Text.Encoding.UTF8.GetBytes(content);

        return File(bytes, "application/pdf", $"{ad}-SinifListesi.pdf");
    }

}
