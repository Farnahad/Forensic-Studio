using DevExpress.Utils;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using ForensicStudio.Core.Control.Core;

namespace ForensicStudio.Core.Control.GridControl.Column;

public abstract class FsGridColumn : GridColumn
{
    public FsGridColumn()
    {
        MinWidth = 40;
        AllowMoving = DefaultBoolean.True;
        AllowColumnFiltering = DefaultBoolean.False;
        EditSettings = new TextEditSettings();

        ControlBehavior.SetFsColumnWidth(this, FsColumnWidth.Star1);
    }
}