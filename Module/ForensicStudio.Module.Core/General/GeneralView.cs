using ForensicStudio.Core.Main.Mvvm;
using System.Windows.Controls;
using ForensicStudio.Core.Control.DockLayout;
using ForensicStudio.Core.Control.Window;

namespace ForensicStudio.Module.Core.General;

public class GeneralView : View
{
    public override void SetTitle(string title)
    {
        base.SetTitle(title);

        if (string.IsNullOrWhiteSpace(title) == false)
        {
            if (Parent is ContentPresenter contentPresenter)
            {
                if (contentPresenter.Parent is FsDocumentPanel fsDocumentPanel)
                {
                    fsDocumentPanel.Caption = title;
                }
            }

            if (Parent is FsDxWindow fsDxWindow)
            {
                fsDxWindow.Title = title;
            }
        }
    }
}