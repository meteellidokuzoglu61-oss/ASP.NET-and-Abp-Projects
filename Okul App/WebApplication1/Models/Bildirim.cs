namespace OgrenciApp.Models
{
    public class Bildirim
    {
        public int Id { get; set; }
        public int OgretmenId { get; set; }
        public string Mesaj { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public bool Okundu { get; set; } = false;
    }






}
