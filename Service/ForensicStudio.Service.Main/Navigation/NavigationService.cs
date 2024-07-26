using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Control.Ribbon;
using ForensicStudio.Core.Main.Mvvm;
using ForensicStudio.Service.Core.Container;
using Prism.Regions;

namespace ForensicStudio.Service.Main.Navigation;

public class NavigationService : INavigationService
{
    private IRegionManager _regionManager;
    private readonly IContainerService _containerService;

    public NavigationService(IRegionManager regionManager,
        IContainerService containerService)
    {
        _regionManager = regionManager;
        _containerService = containerService;
    }

    public void NavigateRibbon<T>() where T : FsRibbonPage
    {
        Navigate<T>("Ribbon");
    }

    public void NavigateDock<T>(FsDockPotion fsDockPotion,
        FsDockType fsDockType = FsDockType.Visible) where T : View
    {
        NavigateToDock<T>(fsDockPotion, fsDockType);
    }

    public void NavigateDock<T>(FsDockPotion fsDockPotion,
        params Tuple<string, object>[] parameters) where T : View
    {
        NavigateToDock<T>(fsDockPotion, FsDockType.Visible, parameters);
    }

    public void NavigateStatusBar<T>() where T : View
    {
        Navigate<T>("StatusBar");
    }

    private void Navigate<T>(string regionName)
    {
        var region = _regionManager.Regions[regionName];

        //var sp = new Stopwatch();
        //sp.Start();
        var view = _containerService.Resolve<T>();
        //sp.Stop();
        //System.Windows.MessageBox.Show(sp.ElapsedMilliseconds.ToString());

        region.Add(view);
        region.Activate(view);
    }

    private void NavigateToDock<T>(FsDockPotion fsDockPotion, FsDockType fsDockType,
        params Tuple<string, object>[] parameters) where T : View
    {
        var viewName = typeof(T).Name;
        _containerService.RegisterNavigation<T>();

        var navigationParameters = new NavigationParameters();
        foreach (var parameter in parameters)
            navigationParameters.Add(parameter.Item1, parameter.Item2);

        if (fsDockType == FsDockType.Visible)
        {
            switch (fsDockPotion)
            {
                case FsDockPotion.Bottom:
                    _regionManager.RequestNavigate("BottomLayoutGroup", viewName, navigationParameters);
                    break;
                case FsDockPotion.Document:
                    _regionManager.RequestNavigate("DocumentLayoutGroup", viewName, navigationParameters);
                    break;
                case FsDockPotion.Left:
                    _regionManager.RequestNavigate("LeftLayoutGroup", viewName, navigationParameters);
                    break;
                case FsDockPotion.Right:
                    _regionManager.RequestNavigate("RightLayoutGroup", viewName, navigationParameters);
                    break;
                case FsDockPotion.Top:
                    _regionManager.RequestNavigate("TopLayoutGroup", viewName, navigationParameters);
                    break;
            }
        }
        else if (fsDockType == FsDockType.Hide)
        {
            switch (fsDockPotion)
            {
                case FsDockPotion.Bottom:
                    _regionManager.RequestNavigate("BottomAutoHideGroup", viewName, navigationParameters);
                    break;
                case FsDockPotion.Document:
                    break;
                case FsDockPotion.Left:
                    _regionManager.RequestNavigate("LeftAutoHideGroup", viewName, navigationParameters);
                    break;
                case FsDockPotion.Right:
                    _regionManager.RequestNavigate("RightAutoHideGroup", viewName, navigationParameters);
                    break;
                case FsDockPotion.Top:
                    _regionManager.RequestNavigate("TopAutoHideGroup", viewName, navigationParameters);
                    break;
            }
        }
    }

    public void Dispose()
    {
        _regionManager = null;
        _containerService?.Dispose();
    }
}