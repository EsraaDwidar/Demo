using Xunit;

namespace Demo.EntityFrameworkCore;

[CollectionDefinition(DemoTestConsts.CollectionDefinitionName)]
public class DemoEntityFrameworkCoreCollection : ICollectionFixture<DemoEntityFrameworkCoreFixture>
{

}
