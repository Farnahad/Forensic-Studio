using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Main.Command;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Module.Tool.EseDatabaseView;
using ForensicStudio.Module.Tool.FtkImager;
using ForensicStudio.Module.Tool.ProcessHacker;
using ForensicStudio.Module.Tool.RegistryExplorer;
using ForensicStudio.Module.Tool.ToolPanel;
using ForensicStudio.Module.Tool.WinPmem;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Main.RibbonPage;

public class FsToolRibbonPageViewModel : GeneralViewModel
{
    public FsToolRibbonPageViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public FsCommand ShowToolPanelViewCommand { get; set; }
    public FsCommand ShowWinPmemViewCommand { get; set; }
    public FsCommand ShowProcessHackerViewCommand { get; set; }
    public FsCommand ShowEseDatabaseViewCommand { get; set; }
    public FsCommand ShowRegistryExplorerViewCommand { get; set; }
    public FsCommand ShowFtkImagerViewCommand { get; set; }

    protected override void InitialCommands()
    {
        base.InitialCommands();

        ShowToolPanelViewCommand = new FsCommand(ShowToolPanelView);
        ShowWinPmemViewCommand = new FsCommand(ShowWinPmemView);
        ShowProcessHackerViewCommand = new FsCommand(ShowProcessHackerView);
        ShowEseDatabaseViewCommand = new FsCommand(ShowEseDatabaseView);
        ShowRegistryExplorerViewCommand = new FsCommand(ShowRegistryExplorerView);
        ShowFtkImagerViewCommand = new FsCommand(ShowFtkImagerView);
    }

    private void ShowToolPanelView()
    {
        NavigationService.NavigateDock<ToolPanelView>(FsDockPotion.Document);
    }

    private void ShowWinPmemView()
    {
        NavigationService.NavigateDock<WinPmemView>(FsDockPotion.Document);
    }

    private void ShowProcessHackerView()
    {
        NavigationService.NavigateDock<ProcessHackerView>(FsDockPotion.Document);
    }

    private void ShowEseDatabaseView()
    {
        NavigationService.NavigateDock<EseDatabaseView>(FsDockPotion.Document);
    }

    private void ShowRegistryExplorerView()
    {
        NavigationService.NavigateDock<RegistryExplorerView>(FsDockPotion.Document);
    }

    private void ShowFtkImagerView()
    {
        NavigationService.NavigateDock<FtkImagerView>(FsDockPotion.Document);
    }

    public override void Dispose()
    {
    }
}