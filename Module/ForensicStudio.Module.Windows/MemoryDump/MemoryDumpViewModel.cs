using ForensicStudio.Core.Main.Command;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.MemoryDump;

public class MemoryDumpViewModel : GeneralViewModel
{
    private readonly MemoryDumpExtractor _memoryDumpExtractor;

    public MemoryDumpViewModel(IContainerService containerService,
    MemoryDumpExtractor memoryDumpExtractor) : base(containerService)
    {
        _memoryDumpExtractor = memoryDumpExtractor;
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
        var methodResult = _memoryDumpExtractor.GetMemoryDump();

        if (methodResult.IsSuccess)
            MemoryDump = methodResult.Result;
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        MemoryDump = null;
    }

    private void Help()
    {
    }

    private Logic.Windows.Model.MemoryDump _memoryDump;
    public Logic.Windows.Model.MemoryDump MemoryDump
    {
        get => _memoryDump;
        set
        {
            _memoryDump = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}