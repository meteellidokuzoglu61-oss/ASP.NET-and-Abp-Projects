using System.Threading.Tasks;
using OkulApplication.Ogrenciler.Dtos;

namespace OkulApplication.Ogrenciler
{
    public interface IOgrenciProfilAppService
    {
        Task<OgrenciProfilDto> GetAsync();
    }
}
