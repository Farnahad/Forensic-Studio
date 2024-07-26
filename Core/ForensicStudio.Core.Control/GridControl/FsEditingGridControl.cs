using DevExpress.Xpf.Grid;

namespace ForensicStudio.Core.Control.GridControl;

public class FsEditingGridControl : FsGridControl
{
    public FsEditingGridControl()
    {
        var fsTableView = (FsTableView)View;
        fsTableView.AllowEditing = true;
        fsTableView.NavigationStyle = GridViewNavigationStyle.Cell;
    }
}