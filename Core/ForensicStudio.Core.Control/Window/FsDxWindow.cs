using System.Windows;
using DevExpress.Xpf.Core;
using ForensicStudio.Core.Control.Core;
using Prism.Services.Dialogs;

namespace ForensicStudio.Core.Control.Window;

public class FsDxWindow : DXWindow, IDialogWindow
{
    public FsDxWindow()
    {
        ShowInTaskbar = false;
        SizeToContent = SizeToContent.WidthAndHeight;
        ResizeMode = ResizeMode.NoResize;
        Title = "Forensic Studio";
        WindowStartupLocation = WindowStartupLocation.CenterOwner;

        ControlBehavior.SetFsFontFamily(this, FsFontFamily.SegoeUi);
        ControlBehavior.SetFsFontSize(this, FsFontSize.Normal);
    }

    public IDialogResult Result { get; set; }
}