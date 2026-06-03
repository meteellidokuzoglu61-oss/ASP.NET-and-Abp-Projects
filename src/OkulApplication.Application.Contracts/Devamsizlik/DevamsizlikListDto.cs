using OkulApplication.Devamsizlik;
using System;

public class DevamsizlikListDto
{
    public string OgrenciAdi { get; set; }
    public DateTime Tarih { get; set; }
    public Devamsizlik_Tipi Tip { get; set; }
}
