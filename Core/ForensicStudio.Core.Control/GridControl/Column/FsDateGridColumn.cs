using System.Windows;
using DevExpress.Xpf.Editors.Settings;
using ForensicStudio.Core.Main.Converter;

namespace ForensicStudio.Core.Control.GridControl.Column;

public class FsDateGridColumn : FsGridColumn
{
    public FsDateGridColumn()
    {
        EditSettings = new TextEditSettings
        {
            DisplayTextConverter = new HijriDateValueConverter(),
            HorizontalContentAlignment = EditSettingsHorizontalAlignment.Right,
            VerticalContentAlignment = VerticalAlignment.Center
        };
    }
}