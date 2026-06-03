using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OkulApplication.Ogretmenler;

public interface IOgretmenAppService :
    ICrudAppService< //Defines CRUD methods
        OgretmenDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateOgretmenDto> //Used to create/update a book
{

}
