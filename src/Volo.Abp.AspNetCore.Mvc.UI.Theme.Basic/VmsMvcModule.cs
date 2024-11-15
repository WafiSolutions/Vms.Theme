using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Vms.Mvc.Theme.Bundling;
using Vms.Mvc.Theme.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Vms.Mvc.Theme;

[DependsOn(
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
    )]
public class VmsMvcModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(VmsMvcModule).Assembly);
        });
    }

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

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<VmsMvcModule>("Vms.Mvc.Theme");
        });

        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new VmsThemeMainTopToolbarContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(VmsThemeBundles.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Styles.Global)
                        .AddContributors(typeof(VmsThemeGlobalStyleContributor));
                });

            options
                .ScriptBundles
                .Add(VmsThemeBundles.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(StandardBundles.Scripts.Global)
                        .AddContributors(typeof(VmsThemeGlobalScriptContributor));
                });
        });
    }
}
