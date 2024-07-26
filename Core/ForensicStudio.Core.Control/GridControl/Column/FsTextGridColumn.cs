using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsTextGridColumn : FsGridColumn
{
    public FsTextGridColumn()
    {
        EditSettings = new TextEditSettings();
    }
}