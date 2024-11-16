using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using VmsTheme.Web.Themes.Vms.Navigation;
using Volo.Abp.AspNetCore.Components.Web.Theming.Layout;

namespace VmsTheme.Server.Shared.Layout.Partials.SidebarLayout.Sidebar;

public partial class SidebarMenuItemMaker : IDisposable
{
    [Inject] protected NavigationManager NavigationManager { get; set; }

    [Inject] protected PageLayout PageLayout { get; set; }

    [Inject] protected IJSRuntime JsRuntime { get; set; }

    [Parameter]
    public MenuViewModel Menu { get; set; }

    [Parameter]
    public MenuItemViewModel MenuItem { get; set; }
    public string show { get; set; }

    protected override void OnParametersSet()
    {
        ActivateCurrentPage();
        PageLayout.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(PageLayout.MenuItemName))
            {
                ActivateCurrentPage();
            }
        };
    }

    protected override void OnInitialized()
    {
        ActivateCurrentPage();
        if (MenuItem.IsOpen)
        {
            show = "show";
            StateHasChanged();
        }

        NavigationManager.LocationChanged += OnLocationChanged;
    }

    protected virtual void OnLocationChanged(object sender, LocationChangedEventArgs e)
    {
        ActivateCurrentPage();
    }

    protected virtual void ActivateCurrentPage()
    {
        if (MenuItem.MenuItem.Url.IsNullOrEmpty())
        {
            return;
        }

        var menuItemPath = MenuItem.MenuItem.Url.Replace("~/", string.Empty).Trim('/');
        var currentPagePath = new Uri(NavigationManager.Uri.TrimEnd('/')).AbsolutePath.Trim('/');

        if (menuItemPath.TrimEnd('/').Equals(currentPagePath, StringComparison.InvariantCultureIgnoreCase) ||
            PageLayout.MenuItemName == MenuItem.MenuItem.Name)
        {
            Menu.Activate(MenuItem);

            var parent = MenuItem.Parent;
            while (parent != null)
            {
                parent.IsOpen = true;
                parent = parent.Parent;
            }
        }
    }

    protected virtual void ToggleMenu()
    {
        Menu.ToggleOpen(MenuItem);
    }

    public virtual void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }
}