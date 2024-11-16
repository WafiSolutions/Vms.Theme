
using VmsTheme.Server._keenthemes.libs;
using Volo.Abp.DependencyInjection;

namespace VmsTheme.Server._keenthemes;

public interface IBootstrapBase : ISingletonDependency
{
    void InitThemeMode();
    
    void InitThemeDirection();
    
    void InitRtl();

    void InitLayout();

    void Init(IKTTheme theme);
}