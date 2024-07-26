using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsIntGridColumn : FsGridColumn
{
    public FsIntGridColumn()
    {
        EditSettings = new SpinEditSettings
        {
            IsFloatValue = false,
            Mask = "N0",
            AllowNullInput = true,
            MinValue = 0M
        };
    }
}