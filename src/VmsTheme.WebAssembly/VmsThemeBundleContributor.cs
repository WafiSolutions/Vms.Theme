using Volo.Abp.Bundling;

namespace VmsTheme.WebAssembly;

public class VmsThemeBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {

    }

    public void AddStyles(BundleContext context)
    {
        context.Add("_content/VmsTheme.Web/libs/abp/css/theme.css");
    }
}
