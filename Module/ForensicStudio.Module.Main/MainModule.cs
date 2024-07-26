using ForensicStudio.Module.Main.RibbonPage;
using ForensicStudio.Module.Main.View.StatusBar;
using ForensicStudio.Service.Main.Navigation;
using Prism.Ioc;
using Prism.Modularity;

namespace ForensicStudio.Module.Main;

public class MainModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var navigationService = containerProvider.Resolve<INavigationService>();

        navigationService.NavigateRibbon<FsWindowsRibbonPageView>();
        navigationService.NavigateRibbon<FsToolRibbonPageView>();
        navigationService.NavigateRibbon<FsFunctionRibbonPageView>();
        navigationService.NavigateRibbon<FsCompanyRibbonPageView>();

        navigationService.NavigateStatusBar<StatusBarView>();
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<StatusBarView>("StatusBarView");
    }
}