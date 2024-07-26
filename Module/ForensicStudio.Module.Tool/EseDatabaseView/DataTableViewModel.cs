using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Tool.EseDatabaseView;

public class DataTableViewModel : GeneralViewModel
{
    protected DataTableViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public override void Dispose()
    {
    }
}