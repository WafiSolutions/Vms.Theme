
using VmsTheme.Web._keenthemes.libs;
using Volo.Abp.DependencyInjection;

namespace VmsTheme.Web._keenthemes;

public interface IBootstrapBase : ISingletonDependency
{
    void InitThemeMode();
    
    void InitThemeDirection();
    
    void InitRtl();

    void InitLayout();

    void Init(IKTTheme theme);
}