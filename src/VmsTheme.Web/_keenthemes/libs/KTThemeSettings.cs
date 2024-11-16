using Microsoft.Extensions.Configuration;

namespace VmsTheme.Web._keenthemes.libs;

public static class KTThemeSettings
{
    public static KTThemeBase Config = new KTThemeBase();

    public static void init(IConfiguration configuration)
    {
        Config = configuration.GetSection("Theme").Get<KTThemeBase>() ?? Config;
    }
}
