using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace VmsTheme.Mvc;

[ThemeName(Name)]
public class VmsTheme : ITheme, ITransientDependency
{
    public const string Name = "Vms";

    public virtual string GetLayout(string name, bool fallbackToDefault = true)
    {
        switch (name)
        {
            case StandardLayouts.Application:
                return "~/Themes/Vms/Layouts/Application.cshtml";
            case StandardLayouts.Account:
                return "~/Themes/Vms/Layouts/Account.cshtml";
            case StandardLayouts.Empty:
                return "~/Themes/Vms/Layouts/Empty.cshtml";
            default:
                return fallbackToDefault ? "~/Themes/Vms/Layouts/Application.cshtml" : null;
        }
    }
}
