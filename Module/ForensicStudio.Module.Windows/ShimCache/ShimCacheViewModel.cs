using ForensicStudio.Core.Main.Command;
using System.Collections.ObjectModel;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.ShimCache;

public class ShimCacheViewModel : GeneralViewModel
{
    private readonly ShimCacheExtractor _shimCacheExtractor;

    public ShimCacheViewModel(IContainerService containerService,
        ShimCacheExtractor shimCacheExtractor) : base(containerService)
    {
        _shimCacheExtractor = shimCacheExtractor;
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
        var methodResult = _shimCacheExtractor.GetShimCaches();

        if (methodResult.IsSuccess)
            ShimCaches = new ObservableCollection<Logic.Windows.Model.ShimCache>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        ShimCaches = new ObservableCollection<Logic.Windows.Model.ShimCache>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.ShimCache> _shimCaches;
    public ObservableCollection<Logic.Windows.Model.ShimCache> ShimCaches
    {
        get => _shimCaches;
        set
        {
            _shimCaches = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.ShimCache _currentShimCache;
    public Logic.Windows.Model.ShimCache CurrentShimCache
    {
        get => _currentShimCache;
        set
        {
            _currentShimCache = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}