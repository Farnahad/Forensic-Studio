using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ForensicStudio.Core.Main.Command;
using ForensicStudio.Core.Main.Window;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Main.View.MvvmLogic;

public class MvvmLogicWindowViewModel : GeneralViewModel
{
    public MvvmLogicWindowViewModel(IContainerService containerService)
        : base(containerService)
    {
        Title = "MVVM Logic";
        Logs = new ObservableCollection<string>();
    }

    public FsCommand CloseCommand { get; set; }

    protected override void InitialCommands()
    {
        base.InitialCommands();

        CloseCommand = new FsCommand(Close);
    }

    private void Close()
    {
        WindowService.Close(this, WindowResult.Ok);
    }

    public override Task LoadAsync()
    {
        Log("Parameter = " + GetParameter<string>("Message"));
        Log("LoadAsync");
        return base.LoadAsync();
    }


    #region ActiveAware

    protected override void OnIsActiveChanged()
    {
        base.OnIsActiveChanged();
        Log("OnIsActiveChanged");
    }

    #endregion


    #region ConfirmNavigationRequest

    protected override bool ConfirmNavigationRequest()
    {
        Log("ConfirmNavigationRequest");
        return true;
    }

    #endregion


    #region DialogAware

    protected override bool CanCloseWindow()
    {
        Log("CanCloseWindow");
        return false;
    }

    protected override void OnWindowClosed()
    {
        base.OnWindowClosed();
        Log("OnWindowClosed");
    }

    protected override void OnWindowOpened()
    {
        base.OnWindowOpened();
        Log("OnWindowOpened");
    }

    #endregion


    #region IDialogAware

    public override bool CanCloseDialog()
    {
        Log("CanCloseDialog");
        return true;
    }

    #endregion

    private ObservableCollection<string> _logs;
    public ObservableCollection<string> Logs
    {
        get => _logs;
        set
        {
            _logs = value;
            OnPropertyChanged();
        }
    }

    private void Log(string log)
    {
        Logs.Add(log);
    }

    public override void Dispose()
    {
    }
}