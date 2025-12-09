using OkulApplication.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace OkulApplication.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class OkulApplicationController : AbpControllerBase
{
    protected OkulApplicationController()
    {
        LocalizationResource = typeof(OkulApplicationResource);
    }
}
