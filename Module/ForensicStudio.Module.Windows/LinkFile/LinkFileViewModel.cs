using ForensicStudio.Core.Main.Command;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.LinkFile;

public class LinkFileViewModel : GeneralViewModel
{
    private readonly LinkFileExtractor _linkFileExtractor;

    public LinkFileViewModel(IContainerService containerService,
    LinkFileExtractor linkFileExtractor) : base(containerService)
    {
        _linkFileExtractor = linkFileExtractor;
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
        var methodResult = _linkFileExtractor.GetLinkFile();

        if (methodResult.IsSuccess)
            LinkFile = methodResult.Result;
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        LinkFile = null;
    }

    private void Help()
    {
    }

    private Logic.Windows.Model.LinkFile _linkFile;
    public Logic.Windows.Model.LinkFile LinkFile
    {
        get => _linkFile;
        set
        {
            _linkFile = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}