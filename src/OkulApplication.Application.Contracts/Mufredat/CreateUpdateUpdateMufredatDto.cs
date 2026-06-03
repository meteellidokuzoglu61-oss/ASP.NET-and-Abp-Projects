using System;

namespace OkulApplication.Mufredatlar;

public class CreateUpdateMufredatDto
{
    public Guid DersId { get; set; }
    public int Sinif { get; set; }
    public int Donem { get; set; }
}
