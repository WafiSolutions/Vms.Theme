using VmsTheme.Server.Bundling;
using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.AspNetCore.Components.Server.Theming.Bundling;
using VmsTheme.Web;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VmsTheme.Web._keenthemes.libs;
using System.IO;
using System.Reflection;
using System;

namespace VmsTheme.Server;

[DependsOn(
    typeof(VmsThemeWebModule),
    typeof(AbpAspNetCoreComponentsServerThemingModule)
    )]
public class VmsThemeServerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new VmsThemeToolbarContributor());
        });

        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(BlazorVmsThemeBundles.Styles.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(BlazorStandardBundles.Styles.Global)
                        .AddContributors(typeof(BlazorVmsThemeStyleContributor));
                });

            options
                .ScriptBundles
                .Add(BlazorVmsThemeBundles.Scripts.Global, bundle =>
                {
                    bundle
                        .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                        .AddContributors(typeof(BlazorVmsThemeScriptContributor));
                });
        });

        ConfigureTheme(context);
    }

    private void ConfigureTheme(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        IConfiguration themeConfiguration = new ConfigurationBuilder()
                                    .AddJsonFile("_keenthemes/config/themesettings.json")
                                    .Build();

        IConfiguration iconsConfiguration = new ConfigurationBuilder()
                                    .AddJsonFile("_keenthemes/config/icons.json")
                                    .Build();

        KTThemeSettings.init(themeConfiguration);
        KTIconsSettings.init(iconsConfiguration);
    }
}
