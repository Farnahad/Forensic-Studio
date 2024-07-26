using Prism.Ioc;

namespace ForensicStudio.Module.Main.RibbonPage;

public partial class FsWindowsRibbonPageView
{
    public FsWindowsRibbonPageView(IContainerExtension containerExtension)
    {
        InitializeComponent();
        DataContext = containerExtension.Resolve<FsWindowsRibbonPageViewModel>();
    }
}