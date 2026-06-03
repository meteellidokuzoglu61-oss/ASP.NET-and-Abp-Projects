using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class AlanController : Controller
{
    // Departments (Bölümler) ve alt dallar
    private List<dynamic> Departments = new List<dynamic>
    {
        new
        {
            Name = "Bilişim Teknolojileri",
            Description = "ALAN HAKKINDA\r\n \r\n\r\nBilişim Teknolojileri alanı, bilgisayar sistemlerinin yazılım ve donanım kurulumu yanında alanın altında yer alan Ağ İşletmenliği, Bilgisayar Teknik Servisi, Veritabanı Programcılığı ve Web Programcılığı dallarının yeterliklerini kazandırmaya yönelik eğitim ve öğretim verilen alandır.\r\n\r\nTeknoloji hızla ilerledikçe Bilişim Teknolojileri alanına olan ihtiyaç daha da artmaya başlamıştır. Bu sebepten Bilişim Teknolojileri alanında bilgi sahibi olan bireylere ihtiyaç duyulmaktadır.\r\n\r\n \r\n\r\nEĞİTİM VE KARİYER İMKÂNLARI\r\n Meslek lisesinden sonra \"Yükseköğretim Kurumları Sınavı\"nda (YKS) başarılı olanlar, lisans programlarına ya da meslek yüksekokullarının ilgili bölümlerine devam edebilirler. Mezun olan öğrencilerin ek puanları ile yerleşebilecekleri ön lisans programları da mevcuttur.\r\n\r\nAğ işletmenleri, bilgisayar satış ve teknik destek firmaları, bankalar, sigorta şirketleri, ticari kuruluşlar, internet servis sağlayıcıları, internet yayıncılık şirketleri, radyo televizyon şirketleri, araştırma şirketleri, borsalar, ulaştırma, lojistik firmaları ve hizmet sektöründe yer alan kamu kuruluşlarında geniş iş imkânlarına sahiptir.\r\n\r\nWeb programcıları ve veritabanıprogramcıları, kamu kuruluşları, bankalar ile özel sektöre ait iş yerleri, internet üzerinden ticaret (e – ticaret) yapan firmalarda çalışabilirler.\r\n\r\nBilgisayar teknik servisi, bilgisayar toplama ve satış işlemi yapan firmalarda, bünyesinde bilgisayar bulunduran iş yerlerinde, şirketlerde ve özel sektöre ait firmalarda çalışabilirler." +
            "Bilişim sektörü firmaları, hizmetleri ile ülke ekonomisine maddi gelir ve istihdam açısından önemli katkılar sağlamaktadır. MEGEP kapsamında Bilişim Teknolojileri alanı altında, bilgisayar teknik servisi, veri tabanı programcılığı, web programcılığı, ağ işletmenliği dallarında öğretim programları hazırlanmıştır.\r\n\r\nTürkiye'de Bilişim sektöründe bu dalların öğretim programlarının hazırlanarak eğitimine başlanması ile sektörde yıllardır süregelen eğitim açığını giderecek önemli bir girişim olacağı düşünülmektedir. MEGEP kapsamında Bilişim Teknolojileri Alanı Çerçeve Öğretim Programının hazırlanmasında, Millî Eğitim Bakanlığı'nda görevli uzman ve alan öğretmenleri, sektör temsilcileri, üniversiteden alan uzmanları ve meslek elemanları ile iş birliği içinde çalışılmıştır.\r\n\r\nBilişim teknolojileri sektörü, küresel düzeyde hızla değişen pazar ve rekabet koşulları nedeni ile sürekli ve dinamik bir gelişim içindedir. Bu özellikleri nedeni ile  bilişim teknolojileri sektörü, stratejik bir sanayi  olarak ülkelerin yakın ilgisini çekmekte ve bu sektör için devletler tarafından özel planlamalar yapılmaktadır. Özellikle hızla küreselleşmekte olan bu sektörde rekabet büyük yoğunluk kazanmakta ve  sanayileşmiş ülkeler bu sektörün korunması ve rekabet gücünün geliştirilmesi için özel politikalar  uygulamaktadır.\r\n\r\nBu bağlamda 2007 2008 eğitim öğretim yılında öğretmen arkadaşlarla konuşarak bölümümüzde piyasada İHTİYAÇ DUYULAN VERİ TABANI PROGRAMCILIĞI açılması kararlaştırılmıştır.\r\n\r\nÖğretim programlarının ve modüllerin hazırlanmasının her aşamasında, iş yaşamının iş gücüne dönük gereksinimlerinin tüm yönleriyle dikkate alınması amacıyla sektörel kuruluşlarla karşılıklı görüş alışverişi ve iş birliği gerçekleştirilmiştir.\r\n\r\nProgram geliştirme sürecinde üniversitelerden uzmanlar ve sivil toplum kuruluşları ile iş birliği yapılmıştır. Sektör taraması ve mesleki yeterliklerin belirlenmesi  sırasında sektöre anket uygulanmıştır. Bu anketler sonucunda Türkiye genelinde bilişim teknolojileri sektörünün ihtiyaçları ve programdan beklentileri tespit edilmiştir. Bu ihtiyaçlar program çalışmalarının temelini oluşturmuştur.\r\n\r\nProgram geliştirme sürecinin her aşamasında bilişim teknolojileri sektörünün önde gelen kuruluşları ile diyalog kurulmuştur. Bu firmaların eğitim sorumluları ve çeşitli  meslek  elemanları ile iletişim kurulmuş ve katkıları sağlanmıştır. Böylelikle sektör beklentileri programa yansıtılmıştır.\r\n\r\nMeslek elemanlarından, ulusal ve uluslararası iş gücünden beklenen yeterlikler de çeşitli araştırmalar ve yabancı uzmanlar ile görüşerek tespit edilerek program çalışmalarına aktarılmıştır.\r\n\r\nBu doğrultuda Bilişim Teknolojileri alanı ve altında yer alan mesleklerde  uluslararası ve ulusal düzeyde standartlara uygun, her yaşta ve düzeyde bireye eğitim olanağı sağlayan programları hazırlamak hedeflenmiştir.\r\n\r\nSektör araştırma ve inceleme çalışmaları sonucunda sektörde faaliyet gösteren meslekler saptanmıştır. Sektörde çalışan kişilerin görüş ve önerilerinden yola çıkılarak her meslek dalına ait anket soruları hazırlanmış, daha sonra bu anketler yurdun değişik  bölgelerinde uygulanarak mesleklere özgü yeterlikler ayrı ayrı ve ayrıntılı olarak çıkarılmıştır. Mesleklere ilişkin olarak saptanan bu yeterlikler, hazırlanacak olan öğretim programları ve modüllerin temel dayanağını ve içeriğini oluşturacaktır.",
            Detail = "Bilişim Teknolojileri alanı öğrencileri yazılım geliştirme, siber güvenlik, ağ yönetimi gibi konularda yetiştirir.",
            ImageUrl = "/images/alanlar/bilisim.png",
            Branches = new List<dynamic>
            {
                new { Name="Yazılım Geliştirme", Description="C#, Java, Python" },
                new { Name="Ağ İşletmenliği ve Siber Güvenlik", Description="Bilgisayar güvenliği ve ağ" }
            }
        },
        new
        {
            Name = "Elektrik-Elektronik",
            Description = "ALAN HAKKINDA\r\n\r\nElektrik-Elektronik Teknolojisi alanı, altında yer alan dallarının yeterliklerini kazandırmaya yönelik eğitim ve öğretim verilen alandır.\r\n\r\nElektrik-Elektronik Teknolojisi alanı bugün diğer tüm alanları geliştiren, temel ve üretken bir sanayiye dönüşmüş durumdadır.\r\n\r\nAlan, bugün kendi tasarım ve teknolojilerini geliştirecek güce ulaşmıştır. Elektrik- Elektronik alanı birçok alanı etkilerken ekonomiye kendi üretimi, ihracatı ve istihdamıyla yaptığı birinci derece katkının yanında, diğer sektörlere olan etkileriyle ikinci derece katkılarda da bulunmaktadır. Bu alandaki teknoloji değişimleri ve kalite artışlarının, sektör ürünlerini girdi olarak kullanan birçok alanda kalitenin artmasına olumlu etkide bulunacağı anlamına gelmektedir." +
            "EĞİTİM VE KARİYER İMKÂNLARI\r\n \r\n\r\nMeslek lisesinden sonra \"Yükseköğretim Kurumları Sınavı\"nda (YKS) başarılı olanlar, lisans programlarına ya da meslek yüksekokullarının ilgili bölümlerine devam edebilirler. Mezun olan öğrencilerin ek puanları ile yerleşebilecekleri ön lisans programları da mevcuttur.\r\n\r\nElektrik-Elektronik Teknolojisi alanında eğitim almış kişiler, kamuya veya özel sektöre ait işletmelerde çalışabilirler, kendi iş yerlerini de açabilirler.",
            Detail = "Elektrik Elektronik alanı enerji sistemleri, devre tasarımı ve bakım onarım eğitimleri sunar.",
            ImageUrl = "/images/alanlar/elektrik.png",
            Branches = new List<dynamic>
            {
                new { Name="Elektrik Tesisatı", Description="Ev ve endüstri tesisatı" },
                new { Name="Elektronik Devreler", Description="Arduino, sensörler, PCB" }
            }
        }
    };

    // Alanlarımız sayfası
    public IActionResult Index()
    {
        ViewBag.Departments = Departments;
        return View();
    }

    // Alan Detay sayfası
    public IActionResult AlanDetay(string name)
    {
        var department = Departments.FirstOrDefault(d => d.Name == name);

        if (department == null)
            return NotFound();

        ViewBag.Department = department;
        return View();
    }
}
