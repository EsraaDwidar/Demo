using Volo.Abp.Modularity;

namespace Demo;

[DependsOn(
    typeof(DemoDomainModule),
    typeof(DemoTestBaseModule)
)]
public class DemoDomainTestModule : AbpModule
{

}
