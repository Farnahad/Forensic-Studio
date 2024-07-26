using DevExpress.Xpf.Grid;

namespace ForensicStudio.Core.Control.GridControl;

public class FsTableView : TableView
{
    public FsTableView()
    {
        ShowGroupPanel = false;
        AllowEditing = false;
        IsSynchronizedWithCurrentItem = true;
        AllowFixedColumnMenu = true;
        EnterMoveNextColumn = true;
        ShowEditFormOnF2Key = false;
        NavigationStyle = GridViewNavigationStyle.Row;
        AllowPerPixelScrolling = true;
        AllowBandMultiRow = true;
        ShowBandsPanel = false;
        UseEvenRowBackground = true;
        ImmediateUpdateRowPosition = false;
    }
}