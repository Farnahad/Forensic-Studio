using DevExpress.Xpf.Grid;

namespace ForensicStudio.Core.Control.GridControl;

public class FsReadingSearchableGridControl : FsReadingGridControl
{
    public FsReadingSearchableGridControl()
    {
        View.ShowSearchPanelMode = ShowSearchPanelMode.Always;
    }
}