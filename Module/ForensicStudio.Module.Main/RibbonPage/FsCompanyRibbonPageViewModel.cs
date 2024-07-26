using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Main.Command;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Module.Main.View.Company;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Main.RibbonPage;

public class FsCompanyRibbonPageViewModel : GeneralViewModel
{
    public FsCompanyRibbonPageViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public FsCommand ShowCompanyPanelViewCommand { get; set; }

    protected override void InitialCommands()
    {
        base.InitialCommands();

        ShowCompanyPanelViewCommand = new FsCommand(ShowCompanyPanelView);
    }

    private void ShowCompanyPanelView()
    {
        NavigationService.NavigateDock<CompanyPanelView>(FsDockPotion.Document);
    }

    public override void Dispose()
    {
    }
}