using System.Threading.Tasks;
using Vms.Server.Theme.Themes.Vms;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace Vms.Server.Theme;

public class VmsToolbarContributor : IToolbarContributor
{
    public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name == StandardToolbars.Main)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
        }

        return Task.CompletedTask;
    }
}
