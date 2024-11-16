using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace VmsTheme.Server._keenthemes.libs;

class KTIconsSettings
{
    public static SortedDictionary<string, int> Config { get; set; } = new SortedDictionary<string, int>();

    public static void init(IConfiguration configuration)
    {
        Config = configuration.GetSection("duotone-paths").Get<SortedDictionary<string, int>>() ?? Config;
    }
}
