using ForensicStudio.Core.Main.Mvvm;

namespace ForensicStudio.Service.Main.DateTime;

public interface IDateTimeService : IService
{
    System.DateTime GetTodayDate();
    System.DateTime GetTodayDateTime();
}