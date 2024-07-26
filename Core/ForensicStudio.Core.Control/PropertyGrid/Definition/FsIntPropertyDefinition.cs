using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.PropertyGrid.Definition;

public class FsIntPropertyDefinition : FsPropertyDefinition
{
    public FsIntPropertyDefinition()
    {
        EditSettings = new SpinEditSettings
        {
            IsFloatValue = false,
            Mask = "N2"
        };
    }
}