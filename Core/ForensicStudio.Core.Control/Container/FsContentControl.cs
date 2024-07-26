using System.Windows;
using System.Windows.Controls;

namespace ForensicStudio.Core.Control.Container;

public class FsContentControl : ContentControl
{
    public FsContentControl()
    {
        VerticalContentAlignment = VerticalAlignment.Stretch;
        HorizontalContentAlignment = HorizontalAlignment.Stretch;
    }
}