using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsPercentIntEditGridColumn : FsIntGridColumn
{
    public FsPercentIntEditGridColumn()
    {
        EditSettings = new SpinEditSettings
        {
            IsFloatValue = false,
            Mask = "P0"
        };
    }
}