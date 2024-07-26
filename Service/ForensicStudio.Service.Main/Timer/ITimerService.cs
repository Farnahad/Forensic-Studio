using ForensicStudio.Core.Main.Mvvm;

namespace ForensicStudio.Service.Main.Timer;

public interface ITimerService : IService
{
    void SetConfig(Action action, int intervalSeconds);
    void Start();
    void Stop();
}