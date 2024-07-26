using ForensicStudio.Core.Main.Command;
using System.Collections.ObjectModel;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.MostRecentlyUsed;

public class MostRecentlyUsedViewModel : GeneralViewModel
{
    private readonly MostRecentlyUsedExtractor _mostRecentlyUsedExtractor;

    public MostRecentlyUsedViewModel(IContainerService containerService,
    MostRecentlyUsedExtractor mostRecentlyUsedExtractor) : base(containerService)
    {
        _mostRecentlyUsedExtractor = mostRecentlyUsedExtractor;
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
        var methodResult = _mostRecentlyUsedExtractor.GetMostRecentlyUseds();

        if (methodResult.IsSuccess)
            MostRecentlyUseds = new ObservableCollection<Logic.Windows.Model.MostRecentlyUsed>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        MostRecentlyUseds = new ObservableCollection<Logic.Windows.Model.MostRecentlyUsed>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.MostRecentlyUsed> _mostRecentlyUseds;
    public ObservableCollection<Logic.Windows.Model.MostRecentlyUsed> MostRecentlyUseds
    {
        get => _mostRecentlyUseds;
        set
        {
            _mostRecentlyUseds = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.MostRecentlyUsed _currentMostRecentlyUsed;
    public Logic.Windows.Model.MostRecentlyUsed CurrentMostRecentlyUsed
    {
        get => _currentMostRecentlyUsed;
        set
        {
            _currentMostRecentlyUsed = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}