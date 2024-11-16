using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Vms.Server.Theme.Bundling;

public class BlazorVmsStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        context.Files.AddIfNotContains("/_content/Vms.Web.Theme/libs/abp/css/theme.css");
    }
}
