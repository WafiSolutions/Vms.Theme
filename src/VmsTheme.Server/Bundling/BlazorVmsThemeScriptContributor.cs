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
        context.Files.AddIfNotContains("/assets/datatable-buttons-extension/js/dataTables.buttons.min.js");
        context.Files.AddIfNotContains("/assets/js/jszip.min.js");
        context.Files.AddIfNotContains("/assets/js/pdfmake.min.js");
        context.Files.AddIfNotContains("/assets/js/vfs_fonts.js");
        context.Files.AddIfNotContains("/assets/datatable-buttons-extension/js/buttons.html5.min.js");
        context.Files.AddIfNotContains("/assets/datatable-buttons-extension/js/buttons.print.min.js");
        context.Files.AddIfNotContains("/assets/js/datatable-helper.js");
        context.Files.AddIfNotContains("/assets/js/modal-helper.js");
    }
}
