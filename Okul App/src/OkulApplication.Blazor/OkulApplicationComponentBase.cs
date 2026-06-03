using OkulApplication.Localization;
using Volo.Abp.AspNetCore.Components;

namespace OkulApplication.Blazor;

public abstract class OkulApplicationComponentBase : AbpComponentBase
{
    protected OkulApplicationComponentBase()
    {
        LocalizationResource = typeof(OkulApplicationResource);
    }
}
