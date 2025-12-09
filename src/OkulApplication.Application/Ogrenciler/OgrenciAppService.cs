using OkulApplication.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OkulApplication.Ogrenciler;

public class OgrenciAppService :
    CrudAppService<
        Ogrenci, //The Ogrenci entity
        OgrenciDto, //Used to show Ogrenci
        Guid, //Primary key of the ogrenci entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateOgrenciDto>, //Used to create/update a ogrenci
    IOgrenciAppService //implement the IBookAppService
{
 
         public OgrenciAppService(IRepository<Ogrenci, Guid> repository)
        : base(repository)
    {
        GetPolicyName = OkulApplicationPermissions.Ogrenciler.Default;
        GetListPolicyName = OkulApplicationPermissions.Ogrenciler.Default;
        CreatePolicyName = OkulApplicationPermissions.Ogrenciler.Create;
        UpdatePolicyName = OkulApplicationPermissions.Ogrenciler.Edit;
        DeletePolicyName = OkulApplicationPermissions.Ogrenciler.Delete;
    }
}