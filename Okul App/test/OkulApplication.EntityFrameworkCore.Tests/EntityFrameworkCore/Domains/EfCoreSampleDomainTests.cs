using OkulApplication.Samples;
using Xunit;

namespace OkulApplication.EntityFrameworkCore.Domains;

[Collection(OkulApplicationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<OkulApplicationEntityFrameworkCoreTestModule>
{

}
