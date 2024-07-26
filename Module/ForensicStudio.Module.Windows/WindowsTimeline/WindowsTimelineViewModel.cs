using ForensicStudio.Core.Main.Command;
using System.Collections.ObjectModel;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.WindowsTimeline;

public class WindowsTimelineViewModel : GeneralViewModel
{
    private readonly WindowsTimelineExtractor _windowsTimelineExtractor;

    public WindowsTimelineViewModel(IContainerService containerService,
        WindowsTimelineExtractor windowsTimelineExtractor) : base(containerService)
    {
        _windowsTimelineExtractor = windowsTimelineExtractor;
    }

    public FsCommand LoadCommand { get; set; }
    public FsCommand ClearCommand { get; set; }
    public FsCommand HelpCommand { get; set; }

    protected override void InitialCommands()
    {
        LoadCommand = new FsCommand(Load);
        ClearCommand = new FsCommand(Clear);
        HelpCommand = new FsCommand(Help);
    }

    private void Load()
    {
        var methodResult = _windowsTimelineExtractor.GetWindowsTimelines();

        if (methodResult.IsSuccess)
            WindowsTimelines = new ObservableCollection<Logic.Windows.Model.WindowsTimeline>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        WindowsTimelines = new ObservableCollection<Logic.Windows.Model.WindowsTimeline>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.WindowsTimeline> _windowsTimelines;
    public ObservableCollection<Logic.Windows.Model.WindowsTimeline> WindowsTimelines
    {
        get => _windowsTimelines;
        set
        {
            _windowsTimelines = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.WindowsTimeline _currentWindowsTimeline;
    public Logic.Windows.Model.WindowsTimeline CurrentWindowsTimeline
    {
        get => _currentWindowsTimeline;
        set
        {
            _currentWindowsTimeline = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}