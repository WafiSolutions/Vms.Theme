using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Vms.Mvc.Theme.Bundling;

public class VmsThemeGlobalScriptContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.Add("/themes/basic/layout.js");
    }
}
