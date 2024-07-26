using DevExpress.Xpf.Bars;

namespace ForensicStudio.Core.Control.Ribbon;

public abstract class FsRibbonBarCheckItem : BarCheckItem
{
    public FsRibbonBarCheckItem()
    {
        GroupIndex = 1;
    }
}