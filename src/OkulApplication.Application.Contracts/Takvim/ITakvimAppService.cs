using OkulApplication.Takvimler;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OkulApplication.Takvimler
{
    public interface ITakvimAppService :
    ICrudAppService< //Defines CRUD methods
        TakvimDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateTakvimDto> //Used to create/update a book
    {

    }

}
