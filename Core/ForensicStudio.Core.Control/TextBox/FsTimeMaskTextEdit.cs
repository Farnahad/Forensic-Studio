using DevExpress.Xpf.Editors;

namespace ForensicStudio.Core.Control.TextBox;

public class FsTimeMaskTextEdit : FsMaskTextEdit
{
    public FsTimeMaskTextEdit()
    {
        EditValueType = typeof(System.DateTime);
        MaskType = MaskType.DateTime;
        Mask = "HH:mm";
        MaskUseAsDisplayFormat = true;
    }
}