using DevExpress.Xpf.Ribbon;

namespace ForensicStudio.Core.Control.Ribbon;

public class FsRibbonControl : RibbonControl
{
    public FsRibbonControl()
    {
        MenuIconStyle = RibbonMenuIconStyle.Office2013;
        RibbonStyle = RibbonStyle.Office2010;
        ApplicationButtonText = "File";
    }
}