using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.AspNetCore.Components.Web.BasicTheme;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;

namespace Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme;

[DependsOn(
    typeof(VmsWebModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
    typeof(AbpHttpClientIdentityModelWebAssemblyModule)
    )]
public class VmsWebAssemblyModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(VmsWebAssemblyModule).Assembly);
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new BasicThemeToolbarContributor());
        });

        if (context.Services.ExecutePreConfiguredActions<AbpAspNetCoreComponentsWebOptions>().IsBlazorWebApp)
        {
            Configure<AuthenticationOptions>(options =>
            {
                options.LoginUrl = "Account/Login";
                options.LogoutUrl = "Account/Logout";
            });
        }
    }
}
