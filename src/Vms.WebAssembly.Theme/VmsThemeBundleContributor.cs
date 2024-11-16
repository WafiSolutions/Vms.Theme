using Volo.Abp.Bundling;

namespace Vms.WebAssembly.Theme;

public class VmsThemeBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("_content/Vms.Web.Theme/libs/abp/css/theme.css");
    }
}
