using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OkulApplication.Ogrenciler;

public interface IOgrenciAppService :
    ICrudAppService< //Defines CRUD methods
        OgrenciDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateOgrenciDto> //Used to create/update a book
{

}
