using Blazorise;
using Castle.Components.DictionaryAdapter.Xml;
using System.Collections.Generic;
using VmsTheme.Web._keenthemes.libs;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using static System.Net.Mime.MediaTypeNames;

namespace VmsTheme.Server.Bundling;

public class BlazorVmsThemeStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Clear();

        context.Files.AddIfNotContains("/_content/Blazorise.Snackbar/blazorise.snackbar.css");
        context.Files.AddIfNotContains("/libs/datatables.net-bs5/css/dataTables.bootstrap5.css");
        context.Files.AddIfNotContains("/libs/abp/aspnetcore-mvc-ui-theme-shared/datatables/datatables-styles.css");

        var KTTheme = new KTTheme();
        foreach (string font in KTTheme.GetFonts())
        {
            context.Files.AddIfNotContains(font);
        }

        foreach (string file in KTTheme.GetGlobalAssets("Css"))
        {
            context.Files.AddIfNotContains(file);
        }
    }
}
