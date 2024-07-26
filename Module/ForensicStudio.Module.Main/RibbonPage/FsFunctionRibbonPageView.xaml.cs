using Prism.Ioc;

namespace ForensicStudio.Module.Main.RibbonPage;

public partial class FsFunctionRibbonPageView
{
    public FsFunctionRibbonPageView(IContainerExtension containerExtension)
    {
        InitializeComponent();
        DataContext = containerExtension.Resolve<FsFunctionRibbonPageViewModel>();
    }
}