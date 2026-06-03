using System;

public class CreateUpdateTakvimDto
{
    public string Baslik { get; set; }
    public DateTime BaslangicTarihi { get; set; }
    public DateTime BitisTarihi { get; set; }
    public TakvimEtkinlikTipi Tip { get; set; }
}
