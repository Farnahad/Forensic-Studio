using DevExpress.Xpf.Editors;

namespace ForensicStudio.Core.Control.Visual;

public class FsIndeterminateProgressBarEdit : FsProgressBarEdit
{
    public FsIndeterminateProgressBarEdit()
    {
        StyleSettings = new ProgressBarMarqueeStyleSettings();
    }
}