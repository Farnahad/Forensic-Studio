using System;
using System.Linq;
using System.Threading.Tasks;
using ForensicStudio.Core.Main.Window;
using ForensicStudio.DataAccess.Wrapper.Core;
using Prism;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace ForensicStudio.Core.Main.Mvvm;

public abstract class ViewModel : NotifyPropertyChangedBase, IActiveAware,
    IConfirmNavigationRequest, IDialogAware, IRegionMemberLifetime, IDisposable
{
    protected ViewModel()
    {
        #region IActiveAware

        IsActiveChanged += OnIsActiveChanged;

        #endregion


        #region IRegionMemberLifetime

        KeepAlive = false;

        #endregion


        // ReSharper disable once VirtualMemberCallInConstructor
        InitialCommands();
    }

    public View View { get; set; }

    protected virtual void InitialCommands()
    {
    }

    public virtual Task LoadAsync()
    {
        return Task.CompletedTask;
    }

    protected T GetParameter<T>(string name)
    {
        if (_navigationParameters != null)
            return _navigationParameters.GetValue<T>(name);

        if (_dialogParameters != null)
            return _dialogParameters.GetValue<T>(name);

        return default;
    }

    protected bool ContainsParameter(string name)
    {
        return (_navigationParameters != null && _navigationParameters.Keys.Contains(name)) ||
               (_dialogParameters != null && _dialogParameters.Keys.Contains(name));
    }


    #region ActiveAware

    protected virtual void OnIsActiveChanged()
    {
    }

    #endregion


    #region ConfirmNavigationRequest

    protected virtual bool ConfirmNavigationRequest()
    {
        return true;
    }

    #endregion


    #region DialogAware

    public void CloseWindow(WindowResult windowResult)
    {
        RequestClose?.Invoke(new DialogResult());
        //OnRequestClose(new DialogResult((ButtonResult)windowResult));
    }

    protected virtual bool CanCloseWindow()
    {
        return true;
    }

    protected virtual void OnWindowClosed()
    {
    }

    protected virtual void OnWindowOpened()
    {
    }

    #endregion


    #region NavigationAware

    protected virtual void OnNavigatedTo()
    {
    }

    protected virtual void OnNavigatedFrom()
    {
    }

    #endregion


    #region IActiveAware

    public bool IsActive { get; set; }
    public event EventHandler IsActiveChanged;

    private void OnIsActiveChanged(object sender, EventArgs e)
    {
        OnIsActiveChanged();
    }

    #endregion


    #region IConfirmNavigationRequest

    public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    {
        continuationCallback(ConfirmNavigationRequest());
    }

    #endregion


    #region IDialogAware

    private IDialogParameters _dialogParameters;

    private string _title;
    public string Title
    {
        get => _title;
        protected set
        {
            _title = value;
            View.SetTitle(_title);
        }
    }

    public event Action<IDialogResult> RequestClose;
    private void OnRequestClose(IDialogResult dialogResult)
    {
        RequestClose?.Invoke(dialogResult);
    }

    public virtual bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
        OnWindowClosed();
    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        _dialogParameters = parameters;
        OnWindowOpened();
    }

    #endregion


    #region INavigationAware

    private NavigationParameters _navigationParameters;

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        OnNavigatedTo();
        _navigationParameters = navigationContext.Parameters;
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
        OnNavigatedFrom();
        _navigationParameters = navigationContext.Parameters;
    }

    #endregion


    #region IRegionMemberLifetime

    public bool KeepAlive { get; }

    #endregion


    #region IDisposable

    public abstract void Dispose();

    #endregion
}