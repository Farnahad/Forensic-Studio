using System.Windows;
using DevExpress.Xpf.Ribbon;
using ForensicStudio.Core.Control.Core;
using Prism.Services.Dialogs;

namespace ForensicStudio.Core.Control.Window;

public class FsDxRibbonWindow : DXRibbonWindow, IDialogWindow
{
    public FsDxRibbonWindow()
    {
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        WindowState = WindowState.Maximized;

        ControlBehavior.SetFsFontFamily(this, FsFontFamily.SegoeUi);
        ControlBehavior.SetFsFontSize(this, FsFontSize.Normal);
    }

    public IDialogResult Result { get; set; }
}