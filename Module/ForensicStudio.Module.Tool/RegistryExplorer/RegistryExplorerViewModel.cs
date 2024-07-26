using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Tool.RegistryExplorer;

public class RegistryExplorerViewModel : GeneralViewModel
{
    protected RegistryExplorerViewModel(IContainerService containerService)
        : base(containerService)
    {
    }

    public override void Dispose()
    {
    }
}