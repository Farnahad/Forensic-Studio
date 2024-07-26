namespace ForensicStudio.Core.Control.ComboBox;

public class FsSearchableComboBoxEdit : FsComboBoxEdit
{
    public FsSearchableComboBoxEdit()
    {
        ValidateOnTextInput = false;
        IsTextEditable = true;
        FilterCondition = DevExpress.Data.Filtering.FilterCondition.Contains;
    }
}