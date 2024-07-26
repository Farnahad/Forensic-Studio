using ForensicStudio.Core.Main.Command;
using System.Collections.ObjectModel;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.Prefetch;

public class PrefetchViewModel : GeneralViewModel
{
    private readonly PrefetchExtractor _prefetchExtractor;

    public PrefetchViewModel(IContainerService containerService,
    PrefetchExtractor prefetchExtractor) : base(containerService)
    {
        _prefetchExtractor = prefetchExtractor;
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
        var methodResult = _prefetchExtractor.GetPrefetches();

        if (methodResult.IsSuccess)
            Prefetches = new ObservableCollection<Logic.Windows.Model.Prefetch>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        Prefetches = new ObservableCollection<Logic.Windows.Model.Prefetch>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.Prefetch> _prefetches;
    public ObservableCollection<Logic.Windows.Model.Prefetch> Prefetches
    {
        get => _prefetches;
        set
        {
            _prefetches = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.Prefetch _currentPrefetch;
    public Logic.Windows.Model.Prefetch CurrentPrefetch
    {
        get => _currentPrefetch;
        set
        {
            _currentPrefetch = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}