using Demo.Samples;
using Xunit;

namespace Demo.EntityFrameworkCore.Applications;

[Collection(DemoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<DemoEntityFrameworkCoreTestModule>
{

}
