using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.PropertyGrid.Definition;

public class FsTextPropertyDefinition : FsPropertyDefinition
{
    public FsTextPropertyDefinition()
    {
        EditSettings = new TextEditSettings();
    }
}