using System.Threading.Tasks;
using VmsTheme.Server.Themes.Vms;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace VmsTheme.Server;

public class VmsThemeToolbarContributor : IToolbarContributor
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
