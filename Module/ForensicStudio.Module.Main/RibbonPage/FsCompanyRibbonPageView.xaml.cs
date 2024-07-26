using Prism.Ioc;

namespace ForensicStudio.Module.Main.RibbonPage;

public partial class FsCompanyRibbonPageView
{
    public FsCompanyRibbonPageView(IContainerExtension containerExtension)
    {
        InitializeComponent();
        DataContext = containerExtension.Resolve<FsCompanyRibbonPageViewModel>();
    }
}