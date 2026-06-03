using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using OkulApplication.Adresler.ViewModels;

namespace OkulApplication.Adresler
{
    public class AdresAppService : ApplicationService
    {
        public Task<List<AdresViewModel>> GetAdreslerAsync()
        {
            var adresler = new List<AdresViewModel>
            {
                new()
                {
                    SirketAdi="Yazılım Uygulama Ofisi",
                    Mahalle="Aydınlıkevler Mahallesi",
                    Sokak="613. Sokak No:45",
                    Ilce="Ortahisar",
                    Sehir="Trabzon",
                    PostaKodu="61040",
                    Telefon="+90 312 123 14 61",
                    Email="info@yazilimofisi.com"
                },
                new()
                {
                    SirketAdi="Ellidokuzoğlu Bilgi Teknolojileri AŞ",
                    Mahalle="Yavuz Selim Mahallesi",
                    Sokak="Anadolu Caddesi No:55",
                    Ilce="Gebze",
                    Sehir="Kocaeli",
                    PostaKodu="41400",
                    Telefon="+90 506 510 59 61",
                    Email="info@ellidokuzogluBT.com"
                }
            };

            return Task.FromResult(adresler);
        }
    }
}
