using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Theming;
using Volo.Abp.Modularity;

namespace Vms.Web.Theme;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebThemingModule)
)]
public class VmsThemeWebModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpThemingOptions>(options =>
        {
            options.Themes.Add<VmsTheme>();

            if (options.DefaultThemeName == null)
            {
                options.DefaultThemeName = VmsTheme.Name;
            }
        });
    }
}