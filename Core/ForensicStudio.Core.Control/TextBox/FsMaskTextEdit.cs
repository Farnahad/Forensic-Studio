using DevExpress.Xpf.Editors.Validation;

namespace ForensicStudio.Core.Control.TextBox;

public abstract class FsMaskTextEdit : FsTextEdit
{
    public FsMaskTextEdit()
    {
        NullText = "Empty";
        MaskUseAsDisplayFormat = true;
        MaskIgnoreBlank = false;
        InvalidValueBehavior = InvalidValueBehavior.AllowLeaveEditor;
    }
}