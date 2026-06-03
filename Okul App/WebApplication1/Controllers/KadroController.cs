using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class KadroController : Controller
{
    public IActionResult Kadromuz()
    {
        // Kadro listesini ViewBag ile gönderiyoruz
        ViewBag.Kadro = new[]
        {
            new { Name = "Ahmet Yılmaz", Title = "Müdür" },
            new { Name = "Ayşe Demir", Title = "Müdür Başyardımcısı" },
            new { Name = "Mehmet Kara", Title = "Teknik Müdür Yardımcısı" },
            new { Name = "Ayhan Karaa", Title = "9.Sınıf Müdür Yardımcısı" },
            new { Name = "Kenan Ardeli", Title = "10.Sınıf Müdür Yardımcısı" },
            new { Name = "Eren Yağızcı", Title = "11.Sınıf Müdür Yardımcısı" },
            new { Name = "Ergün Halaycı", Title = "12.Sınıf Müdür Yardımcısı" },
            new { Name = "Deniz Demirci", Title = "Maol-Mesem Müdür Yardımcısı" },
            new { Name = "Metin Karakoç", Title = "Bilişim Teknolojileri Öğretmeni-Alan Şefi" },
            new { Name = "Ahmet Yılmaz", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Bilişim Teknolojileri Öğretmeni" },
            new { Name = "Soner Cengiz", Title = "Elektrik-Elektronik Öğretmeni-Elektronik " +
            "Alan Şefi" },
            new { Name = "Mehmet Kara", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Elektrik-Elektronik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Mehmet Kara", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Ahmet Yılmaz", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Türk Dili ve Edebiyatı Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Matematik Öğretmeni" },
            new { Name = "Ayşe Demir", Title = "Kimya Öğretmeni" },




        };

        return View();
    }
}
