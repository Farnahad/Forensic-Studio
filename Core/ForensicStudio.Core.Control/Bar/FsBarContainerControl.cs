using DevExpress.Xpf.Bars;

namespace ForensicStudio.Core.Control.Bar;

public class FsBarContainerControl : BarContainerControl
{
    public FsBarContainerControl()
    {
        BarItemDisplayMode = BarItemDisplayMode.ContentAndGlyph;
    }
}