using DevExpress.Xpf.Editors;

namespace ForensicStudio.Core.Control.ComboBox;

public class FsMultiSearchableComboBoxEdit : FsSearchableComboBoxEdit
{
    public FsMultiSearchableComboBoxEdit()
    {
        StyleSettings = new CheckedComboBoxStyleSettings();
    }
}