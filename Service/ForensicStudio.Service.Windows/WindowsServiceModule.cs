using ForensicStudio.Service.Windows.Vulnerability;
using ForensicStudio.Service.Windows.VulnerabilitySource;
using ForensicStudio.Service.Windows.WindowsLookup;
using Prism.Ioc;
using Prism.Modularity;

namespace ForensicStudio.Service.Windows;

public class WindowsServiceModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<IVulnerabilityService, VulnerabilityService>();
        containerRegistry.Register<IVulnerabilitySourceService, VulnerabilitySourceService>();
        containerRegistry.Register<IVulnerabilityLookupDataService, WindowsLookupDataService>();
        containerRegistry.Register<IVulnerabilitySourceLookupDataService, WindowsLookupDataService>();
    }
}