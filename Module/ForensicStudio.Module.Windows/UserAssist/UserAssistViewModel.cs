using ForensicStudio.Core.Main.Command;
using System.Collections.ObjectModel;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.UserAssist;

public class UserAssistViewModel : GeneralViewModel
{
    private readonly UserAssistExtractor _userAssistExtractor;

    public UserAssistViewModel(IContainerService containerService,
        UserAssistExtractor userAssistExtractor) : base(containerService)
    {
        _userAssistExtractor = userAssistExtractor;
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
        var methodResult = _userAssistExtractor.GetUserAssists();

        if (methodResult.IsSuccess)
            UserAssists = new ObservableCollection<Logic.Windows.Model.UserAssist>(methodResult.Result);
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        UserAssists = new ObservableCollection<Logic.Windows.Model.UserAssist>();
    }

    private void Help()
    {
    }

    private ObservableCollection<Logic.Windows.Model.UserAssist> _userAssists;
    public ObservableCollection<Logic.Windows.Model.UserAssist> UserAssists
    {
        get => _userAssists;
        set
        {
            _userAssists = value;
            OnPropertyChanged();
        }
    }

    private Logic.Windows.Model.UserAssist _currentUserAssist;
    public Logic.Windows.Model.UserAssist CurrentUserAssist
    {
        get => _currentUserAssist;
        set
        {
            _currentUserAssist = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}