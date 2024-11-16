using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace VmsTheme.Server.Bundling;

public class BlazorVmsThemeStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/_content/VmsTheme.Web/libs/abp/css/theme.css");
    }
}
