using System.Windows;
using DevExpress.Xpf.Editors.Settings;
using ForensicStudio.Core.Main.Converter;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsDateTimeGridColumn : FsGridColumn
{
    public FsDateTimeGridColumn()
    {
        EditSettings = new TextEditSettings
        {
            DisplayTextConverter = new HijriDateTimeValueConverter(),
            HorizontalContentAlignment = EditSettingsHorizontalAlignment.Right,
            VerticalContentAlignment = VerticalAlignment.Center
        };
    }
}