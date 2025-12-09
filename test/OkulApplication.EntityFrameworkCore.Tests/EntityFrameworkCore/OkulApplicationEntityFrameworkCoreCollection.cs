using Xunit;

namespace OkulApplication.EntityFrameworkCore;

[CollectionDefinition(OkulApplicationTestConsts.CollectionDefinitionName)]
public class OkulApplicationEntityFrameworkCoreCollection : ICollectionFixture<OkulApplicationEntityFrameworkCoreFixture>
{

}
