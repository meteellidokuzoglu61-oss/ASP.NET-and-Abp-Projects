using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using OkulApplication.Notlar.ViewModels;
using OkulApplication.Ogrenciler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;


namespace OkulApplication.Notlar
{
    public class NotAppService : ApplicationService
    {
        private readonly IRepository<Not, Guid> _notRepository;
        private readonly IRepository<Ogrenci, Guid> _ogrenciRepository;

        public NotAppService(
         IRepository<Not, Guid> notRepository,
         IRepository<Ogrenci, Guid> ogrenciRepository)
        {
            _notRepository = notRepository;
            _ogrenciRepository = ogrenciRepository;
        }

        public async Task TopluNotGirisAsync(List<Not> notlar)
        {
            foreach (var not in notlar)
            {
                
                await _notRepository.InsertAsync(not, autoSave: true);
            }
        }

        public async Task<List<Not>> GetTumNotlarAsync()
        {
            return await _notRepository.GetListAsync();
        }

        // Sınıf-şube bazlı rapor
        // Sınıf – Şube bazlı rapor (SAĞLAM)
        public async Task<List<OgrenciNotRaporViewModel>> GetRaporAsync(
    string sinif = null,
    string sube = null)
        {
            // ✅ Önce veriyi RAM'e al (context burada yaşar)
            var notlar = await _notRepository.GetListAsync();
            var ogrenciler = await _ogrenciRepository.GetListAsync();

            // ✅ Bundan sonrası LINQ to Objects (DbContext YOK)
            var query =
                from n in notlar
                join o in ogrenciler
                    on n.Ogrenci_AdiSoyadi equals o.Ogrenci_AdiSoyadi
                where (string.IsNullOrEmpty(sinif) || o.Ogrenci_Sinifi == sinif)
                   && (string.IsNullOrEmpty(sube) || o.Ogrenci_Subesi == sube)
                select new OgrenciNotRaporViewModel
                {
                    OgrenciAdiSoyadi = o.Ogrenci_AdiSoyadi,
                    Sinif = o.Ogrenci_Sinifi,
                    Sube = o.Ogrenci_Subesi,
                    Ders = n.Ders,
                    Sozlu = n.Sozlu,
                    Yazili = n.Yazili,
                    Proje = n.Proje,
                    Ortalama = (n.Sozlu + n.Yazili + n.Proje) / 3
                };

            return query.ToList();
        }






        public byte[] OlusturPdf(List<OgrenciNotRaporViewModel> notlar)
        {
            if (notlar == null || notlar.Count == 0)
                return Array.Empty<byte>();

            using var ms = new MemoryStream();
            var writer = new PdfWriter(ms);
            using var pdf = new PdfDocument(writer);
            using var document = new Document(pdf, PageSize.A4);

            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            document.Add(new Paragraph("Öğrenci Not Raporu")
                .SetFont(boldFont)
                .SetFontSize(16)
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

            document.Add(new Paragraph("\n"));

            Table table = new Table(7); // Ad Soyad, Sınıf, Şube, Ders, Sözlü, Yazılı, Proje
            table.AddHeaderCell(new Cell().Add(new Paragraph("Ad Soyad").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Sınıf").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Şube").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Ders").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Sözlü").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Yazılı").SetFont(boldFont)));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Proje").SetFont(boldFont)));

            foreach (var n in notlar)
            {
                table.AddCell(new Cell().Add(new Paragraph(n.OgrenciAdiSoyadi ?? "").SetFont(normalFont)));
                table.AddCell(new Cell().Add(new Paragraph(n.Sinif ?? "").SetFont(normalFont)));
                table.AddCell(new Cell().Add(new Paragraph(n.Sube ?? "").SetFont(normalFont)));
                table.AddCell(new Cell().Add(new Paragraph(n.Ders ?? "").SetFont(normalFont)));
                table.AddCell(new Cell().Add(new Paragraph(n.Sozlu.ToString()).SetFont(normalFont)));
                table.AddCell(new Cell().Add(new Paragraph(n.Yazili.ToString()).SetFont(normalFont)));
                table.AddCell(new Cell().Add(new Paragraph(n.Proje.ToString()).SetFont(normalFont)));
            }

            document.Add(table);
            document.Close();

            return ms.ToArray();
        }

    }

}