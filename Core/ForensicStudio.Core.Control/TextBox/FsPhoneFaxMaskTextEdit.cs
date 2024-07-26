using DevExpress.Xpf.Editors;

namespace ForensicStudio.Core.Control.TextBox;

public class FsPhoneFaxMaskTextEdit : FsMaskTextEdit
{
    public FsPhoneFaxMaskTextEdit()
    {
        EditValueType = typeof(string);
        Mask = "99999999999";
        MaskType = MaskType.Simple;
    }
}