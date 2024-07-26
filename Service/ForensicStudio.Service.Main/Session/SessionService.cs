using System.Windows;
using ForensicStudio.Service.Core.Container;

namespace ForensicStudio.Service.Main.Session;

public class SessionService : ISessionService
{
    private ISessionService _instance;
    private readonly IContainerService _containerService;

    public ISessionService Instance
    {
        get => _instance ??= _containerService.Resolve<ISessionService>();
        private set => _instance = value;
    }

    public SessionService(IContainerService containerService)
    {
        _containerService = containerService;
        Instance = this;
    }

    public void RunOnUiThread(Action action)
    {
        if (Application.Current.Dispatcher != null)
            Application.Current.Dispatcher.Invoke(action);
    }

    public void ExitApplication()
    {
        Application.Current.Shutdown();
    }

    public void Dispose()
    {
        _instance?.Dispose();
        _containerService?.Dispose();
    }
}