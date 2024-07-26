using System.Windows;
using DevExpress.Data.Filtering;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsComboBoxGridColumn : FsGridColumn
{
    public FsComboBoxGridColumn()
    {
        var comboBoxEditSettings = new ComboBoxEditSettings
        {
            NullValueButtonPlacement = EditorPlacement.EditBox,
            AutoComplete = true,
            FindMode = FindMode.Always,
            IncrementalFiltering = true,
            FilterCondition = FilterCondition.Contains,
            ImmediatePopup = true,
            ValidateOnTextInput = false,
            NullText = "Empty",
            ShowNullText = true,
            AllowNullInput = true
        };

        EditSettings = comboBoxEditSettings;
    }


    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
        nameof(ItemsSource), typeof(object), typeof(FsComboBoxGridColumn),
        new PropertyMetadata(ItemsSourceChanged));

    public object ItemsSource
    {
        get => GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
            ((LookUpEditSettingsBase)((ColumnBase)d).EditSettings).ItemsSource = e.NewValue;
    }


    public static readonly DependencyProperty DisplayMemberProperty = DependencyProperty.Register(
        nameof(DisplayMember), typeof(string), typeof(FsComboBoxGridColumn),
        new PropertyMetadata(DisplayMemberChanged));

    public string DisplayMember
    {
        get => (string)GetValue(DisplayMemberProperty);
        set => SetValue(DisplayMemberProperty, value);
    }

    private static void DisplayMemberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
            ((LookUpEditSettingsBase)((ColumnBase)d).EditSettings).DisplayMember = e.NewValue.ToString();
    }


    public static readonly DependencyProperty ValueMemberProperty = DependencyProperty.Register(
        nameof(ValueMember), typeof(string), typeof(FsComboBoxGridColumn),
        new PropertyMetadata(ValueMemberChanged));

    public string ValueMember
    {
        get => (string)GetValue(ValueMemberProperty);
        set => SetValue(ValueMemberProperty, value);
    }

    private static void ValueMemberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue != null)
            ((LookUpEditSettingsBase)((ColumnBase)d).EditSettings).ValueMember = e.NewValue.ToString();
    }
}