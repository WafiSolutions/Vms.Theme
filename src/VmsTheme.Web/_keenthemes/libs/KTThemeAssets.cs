using System;
using System.Collections.Generic;

namespace VmsTheme.Web._keenthemes.libs;

public class KTThemeAssets
{
    public string Favicon { get; set; } = String.Empty;

    public List<string> Fonts { get; set; } = new List<string>();

    public List<string> Css { get; set; } = new List<string>();

    public List<string> Js { get; set; } = new List<string>();
}