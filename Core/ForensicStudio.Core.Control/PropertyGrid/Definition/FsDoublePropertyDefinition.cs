using DevExpress.Xpf.Editors.Settings;

namespace ForensicStudio.Core.Control.PropertyGrid.Definition;

public class FsDoublePropertyDefinition : FsPropertyDefinition
{
    public FsDoublePropertyDefinition()
    {
        EditSettings = new SpinEditSettings
        {
            IsFloatValue = true,
            Mask = "N2"
        };
    }
}