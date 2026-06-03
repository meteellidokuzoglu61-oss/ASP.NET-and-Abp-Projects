using System.Net;
using System.Net.Mail;

namespace OgrenciApp.Services
{
    public static class BildirimServis
    {
        public static void GonderMail(string alici, string konu, string mesaj)
        {
            try
            {
                var client = new SmtpClient("smtp.server.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("kullanici@server.com", "sifre"),
                    EnableSsl = true,
                };

                client.Send("kullanici@server.com", alici, konu, mesaj);
            }
            catch
            {
                // Hata yakalama, istersen loglayabilirsin
            }
        }

        public static void GonderSMS(string telefon, string mesaj)
        {
            // SMS API entegrasyonu ekleyebilirsin (Twilio vs.)
        }
    }
}
