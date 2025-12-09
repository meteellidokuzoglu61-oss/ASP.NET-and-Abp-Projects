using Microsoft.Extensions.Localization;
using OkulApplication.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace OkulApplication.Blazor;

[Dependency(ReplaceServices = true)]
public class OkulApplicationBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<OkulApplicationResource> _localizer;

    public OkulApplicationBrandingProvider(IStringLocalizer<OkulApplicationResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
