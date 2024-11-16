using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components;
using Volo.Abp.Localization;

namespace VmsTheme.Web;

public abstract class VmsThemeComponentBase : AbpComponentBase
{
    protected VmsThemeComponentBase()
    {
        LocalizationResource = typeof(VmsThemeResource);
    }
}
