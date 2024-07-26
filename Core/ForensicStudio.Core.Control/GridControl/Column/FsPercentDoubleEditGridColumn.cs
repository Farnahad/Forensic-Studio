using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsPercentDoubleEditGridColumn : FsDoubleEditGridColumn
{
    public FsPercentDoubleEditGridColumn()
    {
        EditSettings = new SpinEditSettings
        {
            IsFloatValue = true,
            Mask = "P2"
        };
    }
}