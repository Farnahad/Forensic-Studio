using ForensicStudio.Core.Main.Application;
using ForensicStudio.Module.Windows.Vulnerability;
using ForensicStudio.Module.Windows.VulnerabilitySource;
using Prism.Ioc;

namespace ForensicStudio.Module.Windows;

public class WindowsModule : FsModule
{
    public override void OnInitialized(IContainerProvider containerProvider)
    {
        base.OnInitialized(containerProvider);
    }

    public override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        base.RegisterTypes(containerRegistry);

        containerRegistry.RegisterDialog<VulnerabilitySourceEditView, VulnerabilitySourceEditViewModel>();
        containerRegistry.RegisterDialog<VulnerabilityEditView, VulnerabilityEditViewModel>();
    }
}