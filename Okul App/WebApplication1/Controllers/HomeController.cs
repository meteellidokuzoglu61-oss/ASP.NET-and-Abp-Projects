using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OgrenciApp.Data;
using OgrenciApp.Models;
using OgrenciApp.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;




namespace OgrenciApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly OgrenciContext _context;

        public HomeController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            OgrenciContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }


        public IActionResult TopluNotGiris()
        {
            ViewBag.Ogrenciler = _context.Ogrenciler.ToList();
            ViewBag.Dersler = _context.Dersler.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TopluNotGiris(int donem, List<Not> notlar)
        {
            if (notlar != null && notlar.Count > 0)
            {
                foreach (var n in notlar)
                {
                    var ogr = _context.Ogrenciler.FirstOrDefault(o => o.Ogrenci_ID == n.OgrenciId);

                    if (ogr != null)
                    {
                        n.OgrenciAd = ogr.Ogrenci_AdiSoyadi;
                        n.Donem = donem;

                        _context.Notlar.Add(n);
                    }
                }

                _context.SaveChanges();
            }

            return RedirectToAction(nameof(TopluNotGiris));


        }

        // GET: Tüm Notlar
        public IActionResult NotIndex()
        {
            var notlar = _context.Notlar.ToList();
            return View(notlar);
        }

        // GET: Öğrenciye Göre Notlar
        public IActionResult OgrenciNotlari(int ogrenciId)
        {
            var notlar = _context.Notlar
                .Where(n => n.OgrenciId == ogrenciId)
                .ToList();

            if (!notlar.Any())
                return Content("Bu öğrenciye ait not bulunamadı.");

            return View(notlar);
        }

        public IActionResult OgrenciDetay()
        {
            // Örnek olarak ID=1 öğrenciyi alıyoruz
            int ogrenciId = 1;
            var ogrenci = _context.Ogrenciler.FirstOrDefault(o => o.Ogrenci_ID == ogrenciId);
            if (ogrenci == null)
                return Content("Öğrenci bulunamadı.");

            var notlar = _context.Notlar.Where(n => n.OgrenciId == ogrenciId).ToList();
            ViewBag.Notlar = notlar;

            return View(ogrenci);
        }

        public IActionResult Rapor(string ogrenciAdi)
        {
            // Input string tipine kesinleştir
            string adi = ogrenciAdi?.Trim() ?? "";

            Ogrenci secilenOgrenci = null;

            if (string.IsNullOrEmpty(adi))
            {
                // Boş ise son girilen öğrenciyi al
                var sonNot = _context.Notlar
                    .OrderByDescending(n => n.Id)
                    .FirstOrDefault();

                if (sonNot != null)
                {
                    secilenOgrenci = _context.Ogrenciler
                        .FirstOrDefault(o => o.Ogrenci_ID == sonNot.OgrenciId);
                }
            }
            else
            {
                // Kısmi isim araması: önce listeye çek, sonra LINQ to Objects
                var ogrenciler = _context.Ogrenciler.ToList();
                secilenOgrenci = ogrenciler
                    .FirstOrDefault(o => o.Ogrenci_AdiSoyadi.Contains(adi));
            }

            if (secilenOgrenci == null)
            {
                ViewBag.Notlar = new List<dynamic>();
                ViewBag.SecilenOgrenciAdi = adi;
                return View();
            }

            // Seçilen öğrencinin notları
            var notlar = _context.Notlar
                .Where(n => n.OgrenciId == secilenOgrenci.Ogrenci_ID)
                .Select(n => new
                {
                    n.Donem,
                    n.Proje,
                    n.YaziliSinav,
                    n.Sozlu,
                    GenelOrtalama = ((n.Proje ?? 0) + (n.YaziliSinav ?? 0) + (n.Sozlu ?? 0)) / 3.0,
                    Durum = (((n.Proje ?? 0) + (n.YaziliSinav ?? 0) + (n.Sozlu ?? 0)) / 3.0) >= 50 ? "Geçti" : "Kaldı"
                })
                .OrderBy(n => n.Donem)
                .ToList();

            ViewBag.Notlar = notlar;
            ViewBag.SecilenOgrenciAdi = secilenOgrenci.Ogrenci_AdiSoyadi;

            return View();
        }

        public IActionResult OgretmenRapor(int? ogretmenId, int? donem)
        {
            // Öğretmen listesi
            var ogretmenler = _context.Ogretmenler
                .Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Ogretmen_AdiSoyadi })
                .ToList();

            ViewBag.Ogretmenler = ogretmenler;
            ViewBag.SecilenOgretmenId = ogretmenId;
            ViewBag.SecilenDonem = donem;

            if (!ogretmenId.HasValue)
            {
                ViewBag.Rapor = new List<dynamic>();
                ViewBag.OgretmenAdi = "";
                return View();
            }

            var ogretmen = _context.Ogretmenler.FirstOrDefault(o => o.Id == ogretmenId.Value);
            ViewBag.OgretmenAdi = ogretmen?.Ogretmen_AdiSoyadi ?? "";

            // Ders bazlı rapor
            var dersler = _context.Dersler.Where(d => d.Ogretmen_ID == ogretmenId.Value).ToList();
            var rapor = new List<dynamic>();

            foreach (var ders in dersler)
            {
                var notlar = _context.Notlar
                    .Where(n => n.DersAd == ders.DersAdi && (!donem.HasValue || n.Donem == donem.Value))
                    .Select(n => new
                    {
                        n.OgrenciAd,
                        n.DersAd,
                        n.Proje,
                        n.YaziliSinav,
                        n.Sozlu,
                        GenelOrtalama = ((n.Proje ?? 0) + (n.YaziliSinav ?? 0) + (n.Sozlu ?? 0)) / 3.0,
                        Durum = (((n.Proje ?? 0) + (n.YaziliSinav ?? 0) + (n.Sozlu ?? 0)) / 3.0) >= 50 ? "Geçti" : "Kaldı"
                    }).ToList();

                rapor.AddRange(notlar);
            }

            ViewBag.Rapor = rapor ?? new List<dynamic>();

            return View();
        }

        public IActionResult Delete(int id)
        {
            var devamsizlik = _context.Devamsizliklar.FirstOrDefault(d => d.Id == id);

            if (devamsizlik == null)
                return NotFound();

            return View(devamsizlik);
        }

        // POST: Silme işlemi
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devamsizlik = await _context.Devamsizliklar.FindAsync(id);

            if (devamsizlik == null)
                return NotFound();

            _context.Devamsizliklar.Remove(devamsizlik);
            await _context.SaveChangesAsync();

            return RedirectToAction("DevamsizlikIndex");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Devamsizlik devamsizlik)
        {
            if (string.IsNullOrWhiteSpace(devamsizlik.Ogrenci_AdSoyad))
            {
                ModelState.AddModelError("OgrenciAdi", "Öğrenci adı boş olamaz.");
            }

            if (ModelState.IsValid)
            {
                _context.Devamsizliklar.Add(devamsizlik);
                await _context.SaveChangesAsync();

                return RedirectToAction("DevamsizlikIndex");
            }

            return View(devamsizlik);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var devamsizlik = _context.Devamsizliklar.Find(id);
            if (devamsizlik == null)
                return NotFound();

            return View(devamsizlik);
        }

        // POST: Devamsizlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Devamsizlik devamsizlik)
        {
            if (id != devamsizlik.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devamsizlik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Devamsizliklar.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction("DevamsizlikIndex");
            }

            return View(devamsizlik);
        }




        public IActionResult Index()
        {
            var dersler = _context.Dersler
     .Select(d => new SelectListItem
     {
         Value = d.Id.ToString(),
         Text = d.DersAdi
     })
     .ToList();

            ViewBag.Dersler = dersler;

            return View();





        }


        public IActionResult DevamsizlikIndex()
        {
            var devamsizliklar = _context.Devamsizliklar
                                         .OrderByDescending(d => d.Tarih)
                                         .ToList();
            return View(devamsizliklar);
        }

        public IActionResult Tarihce()
        {
            return View();
        }

        public IActionResult BosKontenjanDetay(int bolumId)
        {
            // Veritabanından tek bir bölüm ve sınıflarını çekiyoruz
            var bolum = _context.Bolumler
                .Include(b => b.Sinif)
                .ThenInclude(s => s.Ogrenciler)
                .FirstOrDefault(b => b.Id == bolumId);

            if (bolum == null)
                return NotFound("Bölüm bulunamadı.");

            // Sadece boş kontenjanlı sınıfları filtrele
            bolum.Sinif = bolum.Sinif
                .Where(s => s.ToplamKontenjan - (s.Ogrenciler?.Count() ?? 0) > 0)
                .ToList();

            // Tek model gönderiyoruz: Bölüm ve sınıfları
            return View(bolum);
        }

        //
        //
        public IActionResult Hakkimizda()
        {
            ViewBag.SchoolName = "Hacı Selimoğlu Mesleki ve Teknik Anadolu Lisesi";
            return View();
        }

        public IActionResult Alanlarimiz()
        {
            ViewBag.Departments = new[]
            {
                new { Name = "Bilişim Teknolojileri", Description = "Yazılım ve donanım alanında eğitim.", ImageUrl = "/images/alanlar/bilgisayar.png" },
                new { Name = "Elektrik-Elektronik Teknolojisi", Description = "Elektrik ve elektronik sistemler eğitimi.", ImageUrl = "/images/alanlar/elektrik.png" }
            };
            return View();
        }

        public IActionResult Kadromuz()
        {
            ViewBag.Kadro = new[]
            {
                new { Name = "Soner Cengiz", Title = "Müdür" },
                new { Name = "Servet Birlik", Title = "Müdür Başyardımcısı" },
                new { Name = "Mehmet Kara", Title = "Teknik Müdür Yardımcısı" },
                new { Name = "Halim Bilici",Title = "Personel" },
                new { Name = "Ayhan Altay", Title = "9.Sınıf Müdür Yardımcısı" },
                new { Name = "Deniz Ağaçlı", Title = "10.Sınıf Müdür Yardımcısı" },
                new { Name = "Zeki Çınar", Title = "11.Sınıf Müdür Yardımcısı" },
                new { Name = "Erkan Kahraman", Title = "12.Sınıf Müdür Yardımcısı" },
                new { Name = "Salih Yavuz",Title = "Personel" }
                // Daha fazla öğretmen eklenebilir
            };
            return View();
        }


        public IActionResult PersonelDetay(string id)
        {
            if (id == "soner")
            {
                ViewBag.Name = "Soner Cengiz";
                ViewBag.Role = "Müdür";
                ViewBag.Education = "Trakya Üniversitesi - Elektrik-Elektronik Mühendisliği";
                ViewBag.Experience = "15 Yıllık Yönetici Tecrübesi";
                ViewBag.Email = "soner.cengiz@okul.edu.tr";
                ViewBag.Phone = "0532 111 22 33";
            }
            else if (id == "servet")
            {
                ViewBag.Name = "Servet Birlik";
                ViewBag.Role = "Müdür Başyardımcısı";
                ViewBag.Education = "İTÜ - Astronomi ve Uzay Mühendisliği";
                ViewBag.Experience = "10 Yıllık Eğitim Yönetimi Tecrübesi";
                ViewBag.Email = "servet.birlik@okul.edu.tr";
                ViewBag.Phone = "0533 444 55 66";
            }
            else if (id == "mehmet")
            {
                ViewBag.Name = "Mehmet Kara";
                ViewBag.Role = "Teknik Müdür Yardımcısı";
                ViewBag.Education = "Gazi Üniversitesi - Elektrik Elektronik";
                ViewBag.Experience = "12 Yıllık Teknik Yönetim Tecrübesi";
                ViewBag.Email = "mehmet.kara@okul.edu.tr";
                ViewBag.Phone = "0541 222 33 44";
            }
            else if (id == "halim")
            {
                ViewBag.Name = "Halim Bilici";
                ViewBag.Role = "Personel";
                ViewBag.Education = "Uludağ Üniversitesi";
                ViewBag.Experience = "2 Yıllık Sosyal Hizmet";
                ViewBag.Email = "halim.bilici@okul.edu.tr";
                ViewBag.Phone = "0555 777 88 99";
            }


            else if (id == "ayhan")
            {
                ViewBag.Name = "Ayhan Altay";
                ViewBag.Role = "9.Sınıf Müdür Yardımcısı";
                ViewBag.Education = "Sakarya Üniversitesi";
                ViewBag.Experience = "10 Yıllık Eğitim Yönetimi Tecrübesi";
                ViewBag.Email = "ayhan.altay@okul.edu.tr";
                ViewBag.Phone = "0533 489 53 60";
            }



            else if (id == "salih")
            {
                ViewBag.Name = "Salih Yavuz";
                ViewBag.Role = "Personel";
                ViewBag.Education = "Gebze Lisesi";
                ViewBag.Experience = "";
                ViewBag.Email = "salih.yavuz@okul.edu.tr";
                ViewBag.Phone = "0555 777 88 99";
            }

            return View();
        }



        public IActionResult OgrenciKarnePdf()
        {
            // Örnek veri (her ders için bir satır)
            // Örnek veri
            var karneler = new List<Karne>
        {
            new Karne { Ogrenci_AdSoyad = "Mete Ellidokuzoğlu",Ogrenci_Bolumu = "Elektrik-Elektronik Teknolojisi"  , Ders_Adi = "Matematik", Notlar = 85, Davranis_Notu = "İyi" },
            new Karne { Ogrenci_AdSoyad = "Mete Ellidokuzoğlu", Ogrenci_Bolumu = "Elektrik-Elektronik Teknolojisi" , Ders_Adi = "Fizik", Notlar = 90, Davranis_Notu = "Çok İyi" },
            new Karne { Ogrenci_AdSoyad = "Mete Ellidokuzoğlu", Ogrenci_Bolumu = "Elektrik-Elektronik Teknolojisi" , Ders_Adi = "Türkçe", Notlar = 95, Davranis_Notu = "İyi" },
        };

            using var ms = new MemoryStream();
            var writer = new PdfWriter(ms);
            var pdf = new PdfDocument(writer);

            // PDF yatay
            var document = new Document(pdf, PageSize.A4.Rotate());

            // Fontlar
            var normalFont = PdfFontFactory.CreateFont("C:/Windows/Fonts/arial.ttf", iText.IO.Font.PdfEncodings.IDENTITY_H);
            var boldFont = PdfFontFactory.CreateFont("C:/Windows/Fonts/arialbd.ttf", iText.IO.Font.PdfEncodings.IDENTITY_H);

            // Başlıklar
            document.Add(new Paragraph("Hacı Selimoğlu Mesleki ve Teknik Anadolu Lisesi")
                .SetFont(boldFont)
                .SetFontSize(22)
                .SetTextAlignment(TextAlignment.CENTER));

            document.Add(new Paragraph("ÖĞRENCİ KARNESİ")
                .SetFont(boldFont)
                .SetFontSize(18)
                .SetTextAlignment(TextAlignment.CENTER));

            document.Add(new Paragraph("\n"));

            // Öğrenci Bilgileri Tablosu
            var ogrenci = karneler[0];
            Table studentInfo = new Table(2);
            studentInfo.SetWidth(UnitValue.CreatePercentValue(50)); // %50 genişlik
            studentInfo.AddCell(new Cell().Add(new Paragraph("Adı Soyadı:").SetFont(boldFont)));
            studentInfo.AddCell(new Cell().Add(new Paragraph(ogrenci.Ogrenci_AdSoyad).SetFont(normalFont)));
            studentInfo.AddCell(new Cell().Add(new Paragraph("Bölümü:").SetFont(boldFont)));
            studentInfo.AddCell(new Cell().Add(new Paragraph(ogrenci.Ogrenci_Bolumu ?? "").SetFont(normalFont)));
            studentInfo.AddCell(new Cell().Add(new Paragraph("Sınıf:").SetFont(boldFont)));
            studentInfo.AddCell(new Cell().Add(new Paragraph("10-A").SetFont(normalFont)));
            studentInfo.AddCell(new Cell().Add(new Paragraph("Numara:").SetFont(boldFont)));
            studentInfo.AddCell(new Cell().Add(new Paragraph("12345").SetFont(normalFont)));

            document.Add(studentInfo);
            document.Add(new Paragraph("\n"));

            // Ders Tablosu
            Table dersTable = new Table(new float[] { 4, 1, 2, 3 }); // Ders, Not, Davranış, Öğretmen Yorumu
            dersTable.SetWidth(UnitValue.CreatePercentValue(100)); // %100 genişlik

            // Başlıklar
            dersTable.AddHeaderCell(new Cell().Add(new Paragraph("Ders").SetFont(boldFont)));
            dersTable.AddHeaderCell(new Cell().Add(new Paragraph("Not").SetFont(boldFont)));
            dersTable.AddHeaderCell(new Cell().Add(new Paragraph("Davranış").SetFont(boldFont)));
            dersTable.AddHeaderCell(new Cell().Add(new Paragraph("Öğretmen Yorumu").SetFont(boldFont)));

            // Ders satırları
            foreach (var k in karneler)
            {
                dersTable.AddCell(new Cell().Add(new Paragraph(k.Ders_Adi).SetFont(normalFont)));
                dersTable.AddCell(new Cell().Add(new Paragraph(k.Notlar.ToString()).SetFont(normalFont)));
                dersTable.AddCell(new Cell().Add(new Paragraph(k.Davranis_Notu).SetFont(normalFont)));
                dersTable.AddCell(new Cell().Add(new Paragraph("İyi performans").SetFont(normalFont)));
            }

            document.Add(dersTable);
            document.Add(new Paragraph("\n\n"));

            // İmza alanları
            Table imzaTable = new Table(3);
            imzaTable.SetWidth(UnitValue.CreatePercentValue(100)); // %100 genişlik
            imzaTable.AddCell(new Cell().Add(new Paragraph("Sınıf Öğretmeni").SetFont(boldFont).SetTextAlignment(TextAlignment.CENTER)));
            imzaTable.AddCell(new Cell().Add(new Paragraph("Müdür").SetFont(boldFont).SetTextAlignment(TextAlignment.CENTER)));
            imzaTable.AddCell(new Cell().Add(new Paragraph("Veli").SetFont(boldFont).SetTextAlignment(TextAlignment.CENTER)));

            document.Add(imzaTable);

            document.Close();

            // PDF tarayıcıya gönder
            return File(ms.ToArray(), "application/pdf", "Karne.pdf");
        }
    }

}

    public class HomeIndexViewModel
    {
        public IEnumerable<Duyuru> Duyurular { get; set; }
        public bool CanCreateExam { get; set; }
    }

