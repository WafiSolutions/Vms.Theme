using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Vms.WebAssembly.Theme.Themes.Vms;
using Volo.Abp.AspNetCore.Components.Web.Theming.Toolbars;

namespace Vms.WebAssembly.Theme;

public class VmsThemeToolbarContributor : IToolbarContributor
{
    public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name == StandardToolbars.Main)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));

            //TODO: Can we find a different way to understand if authentication was configured or not?
            var authenticationStateProvider = context.ServiceProvider
                .GetService<AuthenticationStateProvider>();

            if (authenticationStateProvider != null)
            {
                context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            }
        }

        return Task.CompletedTask;
    }
}
