using ForensicStudio.Core.Main.Command;
using System.Collections.ObjectModel;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.Shellbag;

public class ShellbagViewModel : GeneralViewModel
{
    private readonly ShellbagExtractor _shellbagExtractor;

    public ShellbagViewModel(IContainerService containerService,
    ShellbagExtractor shellbagExtractor) : base(containerService)
    {
        _shellbagExtractor = shellbagExtractor;
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
        var methodResult = _shellbagExtractor.GetShellbags();

        if (methodResult.IsSuccess)
            Shellbags = new ObservableCollection<Logic.Windows.Model.Shellbag>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        Shellbags = new ObservableCollection<Logic.Windows.Model.Shellbag>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.Shellbag> _shellbags;
    public ObservableCollection<Logic.Windows.Model.Shellbag> Shellbags
    {
        get => _shellbags;
        set
        {
            _shellbags = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.Shellbag _currentShellbag;
    public Logic.Windows.Model.Shellbag CurrentShellbag
    {
        get => _currentShellbag;
        set
        {
            _currentShellbag = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}