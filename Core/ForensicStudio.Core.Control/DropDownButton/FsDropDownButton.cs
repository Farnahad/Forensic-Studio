using System.Windows;

namespace ForensicStudio.Core.Control.DropDownButton;

public class FsDropDownButton : DevExpress.Xpf.Core.DropDownButton
{
    public FsDropDownButton()
    {
        MinWidth = 75;
        Margin = new Thickness(2);
    }
}