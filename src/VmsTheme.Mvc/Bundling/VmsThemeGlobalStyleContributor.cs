using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace VmsTheme.Mvc.Bundling;

public class VmsThemeGlobalStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/basic/layout.css");
    }
}
