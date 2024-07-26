using System.Windows.Controls;
using DevExpress.Xpf.LayoutControl;

namespace ForensicStudio.Core.Control.Container;

public class FsFlowLayoutControl : FlowLayoutControl
{
    public FsFlowLayoutControl()
    {
        Orientation = Orientation.Horizontal;
    }
}