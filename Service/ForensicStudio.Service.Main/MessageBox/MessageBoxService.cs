using System.Windows;
using DevExpress.Xpf.Core;
using ForensicStudio.Core.Main.Method;
using ForensicStudio.DataAccess.Model.Core;

namespace ForensicStudio.Service.Main.MessageBox;

public class MessageBoxService : IMessageBoxService
{
    public void ShowInfo(string info, string title = null)
    {
        DXMessageBox.Show(Application.Current.MainWindow, info, title,
            MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
    }

    public bool? ShowYesNo(string question, string title = null)
    {
        switch (DXMessageBox.Show(Application.Current.MainWindow, question, title,
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes))
        {
            case MessageBoxResult.None:
                return null;
            case MessageBoxResult.Yes:
                return true;
            case MessageBoxResult.No:
                return false;
            default:
                return null;
        }
    }

    public void ShowMethodResultMessage(MethodResult methodResult, string title = null)
    {
        DXMessageBox.Show(Application.Current.MainWindow, methodResult.Message, title,
            MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
    }

    public void ShowCaNotBeDeletedMessage(IDbModel dbModel, string title = null)
    {
        DXMessageBox.Show(Application.Current.MainWindow, $"{dbModel} cannot be deleted", title,
            MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
    }

    public void Dispose()
    {
    }
}