using ForensicStudio.Core.Main.Command;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.JumpList;

public class JumpListViewModel : GeneralViewModel
{
    private readonly JumpListExtractor _jumpListExtractor;

    public JumpListViewModel(IContainerService containerService,
    JumpListExtractor jumpListExtractor) : base(containerService)
    {
        _jumpListExtractor = jumpListExtractor;
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
        var methodResult = _jumpListExtractor.GetJumpList();

        if (methodResult.IsSuccess)
            JumpList = methodResult.Result;
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        JumpList = null;
    }

    private void Help()
    {
    }

    private Logic.Windows.Model.JumpList _jumpList;
    public Logic.Windows.Model.JumpList JumpList
    {
        get => _jumpList;
        set
        {
            _jumpList = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}