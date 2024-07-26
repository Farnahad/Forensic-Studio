using ForensicStudio.Core.Main.Mvvm;
using ForensicStudio.Core.Main.Window;
using ForensicStudio.Service.Core.Container;
using ImTools;
using Prism.Ioc;
using Prism.Services.Dialogs;

namespace ForensicStudio.Service.Main.Window;

public class WindowService : IWindowService
{
    private readonly IContainerService _containerService;
    private IDialogService _dialogService;

    public WindowService(IContainerService containerService,
        IDialogService dialogService)
    {
        _containerService = containerService;
        _dialogService = dialogService;
    }

    public void Show<T>() where T : View
    {
        var viewName = typeof(T).Name;

        try
        {
            _dialogService.Show(viewName, result =>
            {
                int i = 999;
            });
        }
        catch (ContainerResolutionException)
        {
            _containerService.RegisterDialog<T>();
            _dialogService.Show(viewName, result =>
            {
                int i = 999;
            });
        }
    }

    public void Show<T>(params Tuple<string, object>[] parameters) where T : View
    {
        var dialogParameters = new DialogParameters();
        parameters.ForEach(item => dialogParameters.Add(item.Item1, item.Item2));

        try
        {
            _dialogService.Show(typeof(T).Name, dialogParameters, _ =>
            {
                int o = 0;
            });
        }
        catch (ContainerResolutionException)
        {
            _containerService.RegisterDialog<T>();
            _dialogService.Show(typeof(T).Name, dialogParameters, _ =>
            {
                int o = 0;
            });
        }
    }

    public void ShowDialog<T>() where T : View
    {
        var viewName = typeof(T).Name;

        try
        {
            _dialogService.ShowDialog(viewName);
        }
        catch (ContainerResolutionException)
        {
            _containerService.RegisterDialog<T>();
            _dialogService.ShowDialog(viewName, _ =>
            {
            });
        }
    }

    public void ShowDialog<T>(params Tuple<string, object>[] parameters) where T : View
    {
        var dialogParameters = new DialogParameters();
        parameters.ForEach(item => dialogParameters.Add(item.Item1, item.Item2));

        try
        {
            _dialogService.ShowDialog(typeof(T).Name, dialogParameters, _ => { });
        }
        catch (ContainerResolutionException)
        {
            _containerService.RegisterDialog<T>();
            _dialogService.ShowDialog(typeof(T).Name, dialogParameters, _ => { });
        }
    }

    public void Close(ViewModel viewModel, WindowResult? windowResult = null)
    {
        viewModel.CloseWindow(windowResult ?? WindowResult.None);
    }

    public void Dispose()
    {
        _containerService?.Dispose();
        _dialogService = null;
    }
}