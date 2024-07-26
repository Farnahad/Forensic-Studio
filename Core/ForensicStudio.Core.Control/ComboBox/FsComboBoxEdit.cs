using System.Windows;
using DevExpress.Xpf.Editors;
using DevExpress.XtraEditors.DXErrorProvider;
using ForensicStudio.Core.Control.Core;

namespace ForensicStudio.Core.Control.ComboBox;

public class FsComboBoxEdit : ComboBoxEdit
{
    public FsComboBoxEdit()
    {
        IsTextEditable = false;
        AutoComplete = true;
        IncrementalFiltering = true;
        ImmediatePopup = true;
        NullValueButtonPlacement = EditorPlacement.EditBox;
        Validate += OnValidate;

        ControlBehavior.SetFsControlWidth(this, FsControlWidth.Auto);
    }

    private void OnValidate(object sender, ValidationEventArgs e)
    {
        if (IsNotNullable && EditValue == null)
        {
            e.IsValid = false;
            e.ErrorContent = "Required !";
            e.ErrorType =  ErrorType.Critical;
        }
        else
        {
            e.IsValid = true;
            e.ErrorContent = null;
            e.ErrorType = ErrorType.None;
        }

        e.Handled = true;
    }


    public static readonly DependencyProperty IsNotNullableProperty = DependencyProperty.Register(
        nameof(IsNotNullable), typeof(bool), typeof(FsComboBoxEdit), new PropertyMetadata(false));

    public bool IsNotNullable
    {
        get => (bool)GetValue(IsNotNullableProperty);
        set => SetValue(IsNotNullableProperty, value);
    }
}