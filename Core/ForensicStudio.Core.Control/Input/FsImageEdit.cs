using DevExpress.Xpf.Editors;

namespace ForensicStudio.Core.Control.Input;

public class FsImageEdit : ImageEdit
{
    public FsImageEdit()
    {
        ShowMenu = false;
        ShowLoadDialogOnClickMode = ShowLoadDialogOnClickMode.Never;
    }
}