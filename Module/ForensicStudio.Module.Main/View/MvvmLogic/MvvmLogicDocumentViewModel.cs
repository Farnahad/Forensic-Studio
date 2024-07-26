using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ForensicStudio.Module.Core.General;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Module.Main.View.MvvmLogic;

public class MvvmLogicDocumentViewModel : GeneralViewModel
{
    public MvvmLogicDocumentViewModel(IContainerService containerService) : base(containerService)
    {
        Title = "MVVM Logic";
        Logs = new ObservableCollection<string>();
    }

    protected override void InitialCommands()
    {
        base.InitialCommands();
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


    #region NavigationAware

    protected override void OnNavigatedTo()
    {
        base.OnNavigatedTo();
        Log("OnNavigatedTo");
    }

    protected override void OnNavigatedFrom()
    {
        base.OnNavigatedFrom();
        Log("OnNavigatedFrom");
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