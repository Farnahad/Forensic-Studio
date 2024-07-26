using System.Windows.Controls;
using DevExpress.Xpf.LayoutControl;

namespace ForensicStudio.Core.Control.Layout;

public class FsLayoutControl : LayoutControl
{
    public FsLayoutControl()
    {
        Orientation = Orientation.Vertical;
        AnimateScrolling = false;
        DragScrolling = false;
    }
}