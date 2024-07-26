using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Main.Command;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Module.Windows.AmCache;
using ForensicStudio.Module.Windows.Bam;
using ForensicStudio.Module.Windows.FunctionPanel;
using ForensicStudio.Module.Windows.Hibernate;
using ForensicStudio.Module.Windows.JumpList;
using ForensicStudio.Module.Windows.LinkFile;
using ForensicStudio.Module.Windows.MemoryDump;
using ForensicStudio.Module.Windows.MostRecentlyUsed;
using ForensicStudio.Module.Windows.Ntfs;
using ForensicStudio.Module.Windows.PageFile;
using ForensicStudio.Module.Windows.Prefetch;
using ForensicStudio.Module.Windows.Shellbag;
using ForensicStudio.Module.Windows.ShimCache;
using ForensicStudio.Module.Windows.SystemResourceMonitoring;
using ForensicStudio.Module.Windows.UserAssist;
using ForensicStudio.Module.Windows.WindowsSearch;
using ForensicStudio.Module.Windows.WindowsTimeline;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Main.RibbonPage;

public class FsFunctionRibbonPageViewModel : GeneralViewModel
{
    public FsFunctionRibbonPageViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public FsCommand ShowFunctionPanelViewCommand { get; set; }


    #region Windows Info

    public FsCommand ShowAmCacheViewCommand { get; set; }
    public FsCommand ShowBamViewCommand { get; set; }
    public FsCommand ShowHibernateViewCommand { get; set; }
    public FsCommand ShowJumpListViewCommand { get; set; }
    public FsCommand ShowLinkFileViewCommand { get; set; }
    public FsCommand ShowMemoryDumpViewCommand { get; set; }
    public FsCommand ShowMostRecentlyUsedViewCommand { get; set; }
    public FsCommand ShowNtfsViewCommand { get; set; }
    public FsCommand ShowPageFileViewCommand { get; set; }
    public FsCommand ShowPrefetchViewCommand { get; set; }
    public FsCommand ShowShellbagViewCommand { get; set; }
    public FsCommand ShowShimCacheViewCommand { get; set; }
    public FsCommand ShowSystemResourceMonitoringViewCommand { get; set; }
    public FsCommand ShowUserAssistViewCommand { get; set; }
    public FsCommand ShowWindowsSearchViewCommand { get; set; }
    public FsCommand ShowWindowsTimelineViewCommand { get; set; }

    #endregion

    protected override void InitialCommands()
    {
        base.InitialCommands();

        ShowFunctionPanelViewCommand = new FsCommand(ShowFunctionPanelView);


        #region Windows Info

        ShowAmCacheViewCommand = new FsCommand(ShowAmCacheView);
        ShowBamViewCommand = new FsCommand(ShowBamView);
        ShowHibernateViewCommand = new FsCommand(ShowHibernateView);
        ShowJumpListViewCommand = new FsCommand(ShowJumpListView);
        ShowLinkFileViewCommand = new FsCommand(ShowLinkFileView);
        ShowMemoryDumpViewCommand = new FsCommand(ShowMemoryDumpView);
        ShowMostRecentlyUsedViewCommand = new FsCommand(ShowMostRecentlyUsedView);
        ShowNtfsViewCommand = new FsCommand(ShowNtfsView);
        ShowPageFileViewCommand = new FsCommand(ShowPageFileView);
        ShowPrefetchViewCommand = new FsCommand(ShowPrefetchView);
        ShowShellbagViewCommand = new FsCommand(ShowShellbagView);
        ShowShimCacheViewCommand = new FsCommand(ShowShimCacheView);
        ShowSystemResourceMonitoringViewCommand = new FsCommand(ShowSystemResourceMonitoringView);
        ShowUserAssistViewCommand = new FsCommand(ShowUserAssistView);
        ShowWindowsSearchViewCommand = new FsCommand(ShowWindowsSearchView);
        ShowWindowsTimelineViewCommand = new FsCommand(ShowWindowsTimelineView);

        #endregion
    }

    private void ShowFunctionPanelView()
    {
        NavigationService.NavigateDock<FunctionPanelView>(FsDockPotion.Document);
    }


    #region Windows Info

    private void ShowAmCacheView()
    {
        NavigationService.NavigateDock<AmCacheView>(FsDockPotion.Document);
    }

    private void ShowBamView()
    {
        NavigationService.NavigateDock<BamView>(FsDockPotion.Document);
    }

    private void ShowHibernateView()
    {
        NavigationService.NavigateDock<HibernateView>(FsDockPotion.Document);
    }

    private void ShowJumpListView()
    {
        NavigationService.NavigateDock<JumpListView>(FsDockPotion.Document);
    }

    private void ShowLinkFileView()
    {
        NavigationService.NavigateDock<LinkFileView>(FsDockPotion.Document);
    }

    private void ShowMemoryDumpView()
    {
        NavigationService.NavigateDock<MemoryDumpView>(FsDockPotion.Document);
    }

    private void ShowMostRecentlyUsedView()
    {
        NavigationService.NavigateDock<MostRecentlyUsedView>(FsDockPotion.Document);
    }

    private void ShowNtfsView()
    {
        NavigationService.NavigateDock<NtfsView>(FsDockPotion.Document);
    }

    private void ShowPageFileView()
    {
        NavigationService.NavigateDock<PageFileView>(FsDockPotion.Document);
    }

    private void ShowPrefetchView()
    {
        NavigationService.NavigateDock<PrefetchView>(FsDockPotion.Document);
    }

    private void ShowShellbagView()
    {
        NavigationService.NavigateDock<ShellbagView>(FsDockPotion.Document);
    }

    private void ShowShimCacheView()
    {
        NavigationService.NavigateDock<ShimCacheView>(FsDockPotion.Document);
    }

    private void ShowSystemResourceMonitoringView()
    {
        NavigationService.NavigateDock<SystemResourceMonitoringView>(FsDockPotion.Document);
    }

    private void ShowUserAssistView()
    {
        NavigationService.NavigateDock<UserAssistView>(FsDockPotion.Document);
    }

    private void ShowWindowsSearchView()
    {
        NavigationService.NavigateDock<WindowsSearchView>(FsDockPotion.Document);
    }

    private void ShowWindowsTimelineView()
    {
        NavigationService.NavigateDock<WindowsTimelineView>(FsDockPotion.Document);
    }

    #endregion

    public override void Dispose()
    {
    }
}