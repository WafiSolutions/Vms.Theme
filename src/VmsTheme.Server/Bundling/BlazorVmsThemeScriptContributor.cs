using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using VmsTheme.Web._keenthemes.libs;
using System.Collections.Generic;

namespace VmsTheme.Server.Bundling;

public class BlazorVmsThemeScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        var KTTheme = new KTTheme();
        foreach (string file in KTTheme.GetGlobalAssets("Js"))
        {
            context.Files.AddIfNotContains(file);
        }

        context.Files.AddIfNotContains("/libs/abp/core/abp.js");
        context.Files.AddIfNotContains("/libs/abp/jquery/abp.jquery.js");
        context.Files.AddIfNotContains("/libs/datatables.net/js/dataTables.min.js");
        context.Files.AddIfNotContains("/libs/datatables.net-bs5/js/dataTables.bootstrap5.js");
        context.Files.AddIfNotContains("/libs/abp/aspnetcore-mvc-ui-theme-shared/datatables/datatables-extensions.js");
        context.Files.AddIfNotContains("/_content/VmsTheme.Web/assets/js/datatable-helper.js");
        context.Files.AddIfNotContains("/_content/VmsTheme.Web/assets/js/modal-helper.js");
    }
}
