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

        // Get the assembly where the resource is embedded
        var assembly = Assembly.GetExecutingAssembly();  // Or use the specific assembly if needed

        // The full name of the resource: it will be based on the namespace and file path.
        string themesettings = "VmsTheme.Server._keenthemes.config.themesettings.json";
        string icons = "VmsTheme.Server._keenthemes.config.icons.json";

        // Open the embedded resource stream
        using (var stream = assembly.GetManifestResourceStream(themesettings))
        {
            if (stream == null)
                throw new FileNotFoundException($"Resource {themesettings} not found.");

            // Build the configuration using the stream
            var configuration = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            KTThemeSettings.init(configuration);
        }

        // Open the embedded resource stream
        using (var stream = assembly.GetManifestResourceStream(icons))
        {
            if (stream == null)
                throw new FileNotFoundException($"Resource {icons} not found.");

            // Build the configuration using the stream
            var configuration = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            KTThemeSettings.init(configuration);
        }
    }
}
