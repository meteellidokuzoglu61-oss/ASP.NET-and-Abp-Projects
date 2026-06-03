using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OkulApplication.Ogrenci_Belgeler
{
    public interface IOgrenciBelgeAppService
        :
    
        ICrudAppService<
           OgrenciBelgeDto,
           Guid,
           PagedAndSortedResultRequestDto,
           CreateUpdateOgrenciBelgeDto>
        { }








    
}

