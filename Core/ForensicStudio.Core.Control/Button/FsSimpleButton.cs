using System.Windows;
using DevExpress.Xpf.Core;

namespace ForensicStudio.Core.Control.Button;

public class FsSimpleButton : SimpleButton
{
    public FsSimpleButton()
    {
        MinWidth = 75;
        Margin = new Thickness(2);
    }
}