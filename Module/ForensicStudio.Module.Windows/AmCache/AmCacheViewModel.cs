using System.Collections.ObjectModel;
using ForensicStudio.Core.Main.Command;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.AmCache;

public class AmCacheViewModel : GeneralViewModel
{
    private readonly AmCacheExtractor _amCacheExtractor;

    public AmCacheViewModel(IContainerService containerService,
        AmCacheExtractor amCacheExtractor) : base(containerService)
    {
        _amCacheExtractor = amCacheExtractor;
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
        var methodResult = _amCacheExtractor.GetAmCaches();

        if (methodResult.IsSuccess)
            AmCaches = new ObservableCollection<Logic.Windows.Model.AmCache>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        AmCaches = new ObservableCollection<Logic.Windows.Model.AmCache>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.AmCache> _amCaches;
    public ObservableCollection<Logic.Windows.Model.AmCache> AmCaches
    {
        get => _amCaches;
        set
        {
            _amCaches = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.AmCache _currentAmCache;
    public Logic.Windows.Model.AmCache CurrentAmCache
    {
        get => _currentAmCache;
        set
        {
            _currentAmCache = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}