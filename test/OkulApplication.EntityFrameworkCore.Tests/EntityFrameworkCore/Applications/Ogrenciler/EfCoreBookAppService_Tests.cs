using OkulApplication.Ogrenciler;
using Xunit;

namespace OkulApplication.EntityFrameworkCore.Applications.Ogrenciler;

[Collection(OkulApplicationTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : OgrenciAppService_Tests<OkulApplicationEntityFrameworkCoreTestModule>
{

}
