using ForensicStudio.Core.Main.Command;
using System.Collections.ObjectModel;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.Bam;

public class BamViewModel : GeneralViewModel
{
    private readonly BamExtractor _bamExtractor;

    public BamViewModel(BamExtractor bamExtractor,
        IContainerService containerService) : base(containerService)
    {
        _bamExtractor = bamExtractor;
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
        var methodResult = _bamExtractor.GetBams();

        if (methodResult.IsSuccess)
            Bams = new ObservableCollection<Logic.Windows.Model.Bam>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        Bams = new ObservableCollection<Logic.Windows.Model.Bam>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.Bam> _bams;
    public ObservableCollection<Logic.Windows.Model.Bam> Bams
    {
        get => _bams;
        set
        {
            _bams = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.Bam _currentBam;
    public Logic.Windows.Model.Bam CurrentBam
    {
        get => _currentBam;
        set
        {
            _currentBam = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}