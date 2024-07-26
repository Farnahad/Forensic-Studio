using System.Windows;

namespace ForensicStudio.Service.Main.Timer;

public class TimerService : ITimerService
{
    private readonly System.Timers.Timer _timer;
    private Action _action;

    public TimerService(System.Timers.Timer timer)
    {
        _timer = timer;
    }

    public void SetConfig(Action action, int intervalSeconds)
    {
        _timer.Stop();
        _timer.Interval = intervalSeconds * 1000;
        _action = action;
        _timer.Elapsed += (_, _) =>
        {
            if (Application.Current.Dispatcher != null)
                Application.Current.Dispatcher.Invoke((Delegate)_action);
        };
    }

    public void Start()
    {
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}