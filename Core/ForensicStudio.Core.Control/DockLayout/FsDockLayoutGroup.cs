using System.Windows;
using DevExpress.Xpf.Docking;

namespace ForensicStudio.Core.Control.DockLayout;

public abstract class FsDockLayoutGroup : LayoutGroup
{
    public FsDockLayoutGroup()
    {
        HorizontalAlignment = HorizontalAlignment.Stretch;
        VerticalAlignment = VerticalAlignment.Stretch;
    }
}