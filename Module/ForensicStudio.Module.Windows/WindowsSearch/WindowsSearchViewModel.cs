using ForensicStudio.Core.Main.Command;
using System.Collections.ObjectModel;
using ForensicStudio.Logic.Windows.Extractor.WindowsSearch;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.WindowsSearch;

public class WindowsSearchViewModel : GeneralViewModel
{
    private readonly WindowsSearchExtractor _windowsSearchExtractor;

    public WindowsSearchViewModel(IContainerService containerService,
        WindowsSearchExtractor windowsSearchExtractor) : base(containerService)
    {
        _windowsSearchExtractor = windowsSearchExtractor;
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
        var methodResult = _windowsSearchExtractor.GetWindowsSearches();

        if (methodResult.IsSuccess)
            WindowsSearches = new ObservableCollection<Logic.Windows.Model.WindowsSearch>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        WindowsSearches = new ObservableCollection<Logic.Windows.Model.WindowsSearch>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.WindowsSearch> _windowsSearches;
    public ObservableCollection<Logic.Windows.Model.WindowsSearch> WindowsSearches
    {
        get => _windowsSearches;
        set
        {
            _windowsSearches = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.WindowsSearch _currentWindowsSearch;
    public Logic.Windows.Model.WindowsSearch CurrentWindowsSearch
    {
        get => _currentWindowsSearch;
        set
        {
            _currentWindowsSearch = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}