using System;
using Vms.Web.Theme.Themes.Vms;
using Vms.Web.Theme.Themes.Vms;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;
using Volo.Abp.AspNetCore.Components.Web.Theming.Theming;
using Volo.Abp.DependencyInjection;

namespace Vms.Web.Theme;

[ThemeName(Name)]
public class VmsTheme : ITheme, ITransientDependency
{
    public const string Name = "Vms";

    public virtual Type GetLayout(string name, bool fallbackToDefault = true)
    {
        switch (name)
        {
            case StandardLayouts.Application:
            case StandardLayouts.Account:
            case StandardLayouts.Empty:
                return typeof(Vms.Web.Theme.Themes.Vms.MainLayout);
            default:
                return fallbackToDefault ? typeof(Vms.Web.Theme.Themes.Vms.MainLayout) : typeof(NullLayout);
        }
    }
}