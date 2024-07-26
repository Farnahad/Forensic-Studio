using DevExpress.Xpf.Editors;

// 
namespace ForensicStudio.Core.Control.List;

public class FsCheckedListBoxEdit : FsListBoxEdit
{
    public FsCheckedListBoxEdit()
    {
        StyleSettings = new CheckedListBoxEditStyleSettings();
    }
}