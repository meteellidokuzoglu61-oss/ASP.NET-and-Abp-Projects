using OkulApplication.Samples;
using Xunit;

namespace OkulApplication.EntityFrameworkCore.Applications;

[Collection(OkulApplicationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<OkulApplicationEntityFrameworkCoreTestModule>
{

}
