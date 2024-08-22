using Volo.Abp.Modularity;

namespace Demo;

public abstract class DemoApplicationTestBase<TStartupModule> : DemoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
