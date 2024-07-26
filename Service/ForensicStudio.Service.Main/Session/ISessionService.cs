using ForensicStudio.Core.Main.Mvvm;

namespace ForensicStudio.Service.Main.Session;

public interface ISessionService : IService
{
    ISessionService Instance { get; }
    void RunOnUiThread(Action action);
    void ExitApplication();
}