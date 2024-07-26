using Prism.Ioc;

namespace ForensicStudio.Module.Main.RibbonPage;

public partial class FsToolRibbonPageView
{
    public FsToolRibbonPageView(IContainerExtension containerExtension)
    {
        InitializeComponent();
        DataContext = containerExtension.Resolve<FsToolRibbonPageViewModel>();
    }
}