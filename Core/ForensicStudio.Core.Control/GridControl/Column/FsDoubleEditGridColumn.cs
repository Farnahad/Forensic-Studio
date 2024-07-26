using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsDoubleEditGridColumn : FsGridColumn
{
    public FsDoubleEditGridColumn()
    {
        EditSettings = new SpinEditSettings
        {
            IsFloatValue = true,
            Mask = "N2"
        };
    }
}