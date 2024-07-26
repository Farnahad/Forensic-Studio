using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Control.Ribbon;
using ForensicStudio.Core.Main.Mvvm;

namespace ForensicStudio.Service.Main.Navigation;

public interface INavigationService : IService
{
    void NavigateRibbon<T>() where T : FsRibbonPage;
    void NavigateDock<T>(FsDockPotion fsDockPotion, FsDockType fsDockType = FsDockType.Visible) where T : View;
    void NavigateDock<T>(FsDockPotion fsDockPotion, params Tuple<string, object>[] parameters) where T : View;
    void NavigateStatusBar<T>() where T : View;
}