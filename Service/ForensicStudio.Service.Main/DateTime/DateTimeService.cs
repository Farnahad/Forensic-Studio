namespace ForensicStudio.Service.Main.DateTime;

public class DateTimeService : IDateTimeService
{
    public System.DateTime GetTodayDate()
    {
        return System.DateTime.Today;
    }

    public System.DateTime GetTodayDateTime()
    {
        return System.DateTime.Now;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}