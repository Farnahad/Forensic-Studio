using System.Windows;
using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsCenterComboBoxGridColumn : FsComboBoxGridColumn
{
    public FsCenterComboBoxGridColumn()
    {
        HorizontalHeaderContentAlignment = HorizontalAlignment.Center;
        EditSettings.HorizontalContentAlignment = EditSettingsHorizontalAlignment.Center;
    }
}