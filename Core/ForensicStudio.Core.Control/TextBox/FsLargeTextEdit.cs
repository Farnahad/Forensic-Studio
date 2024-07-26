using System.Windows;
using System.Windows.Controls;

namespace ForensicStudio.Core.Control.TextBox;

public class FsLargeTextEdit : FsTextEdit
{
    public FsLargeTextEdit()
    {
        VerticalContentAlignment = VerticalAlignment.Top;
        AcceptsReturn = true;
        TextWrapping = TextWrapping.Wrap;
        HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        Loaded += FsLargeTextEdit_Loaded;

        MinHeight = 100;
    }

    private void FsLargeTextEdit_Loaded(object sender, RoutedEventArgs e)
    {
        MaxWidth = ActualWidth;
        MaxHeight = ActualHeight;
    }
}