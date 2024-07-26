using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsCheckEditGridColumn : FsGridColumn
{
    public FsCheckEditGridColumn()
    {
        EditSettings = new CheckEditSettings();
    }
}