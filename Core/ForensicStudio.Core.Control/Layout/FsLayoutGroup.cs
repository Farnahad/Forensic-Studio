using System.Windows;
using DevExpress.Xpf.LayoutControl;

namespace ForensicStudio.Core.Control.Layout;

public abstract class FsLayoutGroup : LayoutGroup
{
    public FsLayoutGroup()
    {
        HorizontalAlignment = HorizontalAlignment.Stretch;
        VerticalAlignment = VerticalAlignment.Stretch;
    }
}