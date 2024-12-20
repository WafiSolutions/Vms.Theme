﻿using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Theming;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace VmsTheme.Web;

[DependsOn(
    typeof(AbpAspNetCoreComponentsWebThemingModule)
)]
public class VmsThemeWebModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpThemingOptions>(options =>
        {
            options.Themes.Add<VmsThemeLayout>();

            if (options.DefaultThemeName == null)
            {
                options.DefaultThemeName = VmsThemeLayout.Name;
            }
        });
    }
}