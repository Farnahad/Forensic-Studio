using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Tool.EseDatabaseView;

public class EseDatabaseViewModel : GeneralViewModel
{
    protected EseDatabaseViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public override void Dispose()
    {
    }
}