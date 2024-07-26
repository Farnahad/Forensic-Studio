using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Main.Command;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Module.Windows.Vulnerability;
using ForensicStudio.Module.Windows.VulnerabilitySource;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Main.RibbonPage;

public class FsWindowsRibbonPageViewModel : GeneralViewModel
{
    public FsWindowsRibbonPageViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public FsCommand ShowVulnerabilityListViewCommand { get; set; }
    public FsCommand ShowVulnerabilitySourceListViewCommand { get; set; }

    protected override void InitialCommands()
    {
        base.InitialCommands();

        ShowVulnerabilityListViewCommand = new FsCommand(ShowVulnerabilityListView);
        ShowVulnerabilitySourceListViewCommand = new FsCommand(ShowVulnerabilitySourceListView);
    }

    private void ShowVulnerabilityListView()
    {
        NavigationService.NavigateDock<VulnerabilityListView>(FsDockPotion.Document);
    }

    private void ShowVulnerabilitySourceListView()
    {
        NavigationService.NavigateDock<VulnerabilitySourceListView>(FsDockPotion.Document);
    }

    public override void Dispose()
    {
    }
}