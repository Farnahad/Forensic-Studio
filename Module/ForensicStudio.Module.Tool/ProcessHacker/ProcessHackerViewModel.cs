using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Tool.ProcessHacker;

public class ProcessHackerViewModel : GeneralViewModel
{
    protected ProcessHackerViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public override void Dispose()
    {
    }
}