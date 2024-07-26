using ForensicStudio.Core.Main.Command;
using ForensicStudio.Logic.Windows.Extractor;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Windows.SystemResourceMonitoring;

public class SystemResourceMonitoringViewModel : GeneralViewModel
{
    private readonly SystemResourceMonitoringExtractor _systemResourceMonitoringExtractor;

    public SystemResourceMonitoringViewModel(IContainerService containerService,
        SystemResourceMonitoringExtractor systemResourceMonitoringExtractor) : base(containerService)
    {
        _systemResourceMonitoringExtractor = systemResourceMonitoringExtractor;
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
        var methodResult = _systemResourceMonitoringExtractor.GetSystemResourceMonitorings();

        if (methodResult.IsSuccess)
            SystemResourceMonitoring = methodResult.Result;
        else
            MessageBoxService.ShowMethodResultMessage(methodResult);
    }

    private void Clear()
    {
        SystemResourceMonitoring = null;
    }

    private void Help()
    {
    }

    private Logic.Windows.Model.SystemResourceMonitoring _systemResourceMonitoring;
    public Logic.Windows.Model.SystemResourceMonitoring SystemResourceMonitoring
    {
        get => _systemResourceMonitoring;
        set
        {
            _systemResourceMonitoring = value;
            OnPropertyChanged();
        }
    }

    public override void Dispose()
    {
    }
}