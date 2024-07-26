using DevExpress.Xpf.Bars;

namespace ForensicStudio.Core.Control.Bar;

public class FsToolBarControl : ToolBarControl
{
    public FsToolBarControl()
    {
        ActualShowDragWidget = false;
        AllowCustomizationMenu = false;
        AllowQuickCustomization = false;
        BarItemDisplayMode = BarItemDisplayMode.ContentAndGlyph;
    }
}