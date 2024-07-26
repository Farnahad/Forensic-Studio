using DevExpress.Xpf.Editors;

namespace ForensicStudio.Core.Control.TextBox;

public abstract class FsSpinEdit : SpinEdit
{
    public FsSpinEdit()
    {
        AllowNullInput = true;
        NullText = "Empty";
        MaskUseAsDisplayFormat = true;
        ShowEditorButtons = true;
    }
}