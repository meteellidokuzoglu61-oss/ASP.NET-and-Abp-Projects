using System;
using System.Collections.Generic;
using System.Text;
using OkulApplication.Localization;
using Volo.Abp.Application.Services;

namespace OkulApplication;

/* Inherit your application services from this class.
 */
public abstract class OkulApplicationAppService : ApplicationService
{
    protected OkulApplicationAppService()
    {
        LocalizationResource = typeof(OkulApplicationResource);
    }
}
