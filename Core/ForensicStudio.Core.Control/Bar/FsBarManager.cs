using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;

namespace ForensicStudio.Core.Control.Bar;

public class FsBarManager : BarManager
{
    public FsBarManager()
    {
        CreateStandardLayout = false;
        WorkspaceManager.SetIsEnabled(this, true);
    }
}