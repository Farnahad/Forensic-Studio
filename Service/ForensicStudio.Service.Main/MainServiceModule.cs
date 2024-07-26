using ForensicStudio.Service.Main.Cryptography;
using ForensicStudio.Service.Main.DateTime;
using ForensicStudio.Service.Main.Json;
using ForensicStudio.Service.Main.Log;
using ForensicStudio.Service.Main.MessageBox;
using ForensicStudio.Service.Main.Navigation;
using ForensicStudio.Service.Main.Session;
using ForensicStudio.Service.Main.Text;
using ForensicStudio.Service.Main.Timer;
using ForensicStudio.Service.Main.Utility;
using ForensicStudio.Service.Main.Window;
using Prism.Ioc;
using Prism.Modularity;

namespace ForensicStudio.Service.Main;

public class MainServiceModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.Register<ICryptographyService, CryptographyService>();
        containerRegistry.Register<IDateTimeService, DateTimeService>();
        //containerRegistry.Register(typeof(IDatabaseService<>), typeof(DatabaseService<>));
        containerRegistry.Register<IJsonService, JsonService>();
        containerRegistry.Register<ILogService, LogService>();
        containerRegistry.Register<IMessageBoxService, MessageBoxService>();
        containerRegistry.Register<INavigationService, NavigationService>();
        containerRegistry.Register<ISessionService, SessionService>();
        containerRegistry.Register<ITextService, TextService>();
        containerRegistry.Register<ITimerService, TimerService>();
        containerRegistry.Register<IUtilityService, UtilityService>();
        containerRegistry.Register<IWindowService, WindowService>();
    }
}