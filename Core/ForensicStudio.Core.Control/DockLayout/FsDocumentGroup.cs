using DevExpress.Xpf.Docking;

namespace ForensicStudio.Core.Control.DockLayout;

public class FsDocumentGroup : DocumentGroup
{
    public FsDocumentGroup()
    {
        ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders;
    }
}