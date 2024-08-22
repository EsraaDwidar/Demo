using Demo.Samples;
using Xunit;

namespace Demo.EntityFrameworkCore.Domains;

[Collection(DemoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<DemoEntityFrameworkCoreTestModule>
{

}
