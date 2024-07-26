using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Grid;

namespace ForensicStudio.Core.Control.GridControl;

public abstract class FsGridControl : DevExpress.Xpf.Grid.GridControl
{
    public FsGridControl()
    {
        SelectionMode = MultiSelectMode.None;

        var fsTableView = new FsTableView();
        View = fsTableView;
    }

    public static readonly DependencyProperty MouseDoubleClickCommandProperty = DependencyProperty.Register(
        nameof(MouseDoubleClickCommand), typeof(ICommand), typeof(FsGridControl),
        new PropertyMetadata(null));

    public ICommand MouseDoubleClickCommand
    {
        get => (ICommand)GetValue(MouseDoubleClickCommandProperty);
        set => SetValue(MouseDoubleClickCommandProperty, value);
    }
}