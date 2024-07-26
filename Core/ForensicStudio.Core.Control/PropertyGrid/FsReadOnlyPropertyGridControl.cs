namespace ForensicStudio.Core.Control.PropertyGrid;

public class FsReadOnlyPropertyGridControl : FsPropertyGridControl
{
    public FsReadOnlyPropertyGridControl()
    {
        ReadOnly = true;
    }
}