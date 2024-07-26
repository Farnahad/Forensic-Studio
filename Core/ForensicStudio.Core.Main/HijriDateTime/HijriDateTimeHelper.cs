using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace ForensicStudio.Core.Main.HijriDateTime;

public static class HijriDateTimeHelper
{
    private static readonly PersianCalendar PersianCalendar = new PersianCalendar();

    public static string GetHijriDateString(this DateTime dateTime)
    {
        var dayOfMonth = PersianCalendar.GetDayOfMonth(dateTime);
        var month = PersianCalendar.GetMonth(dateTime);
        var year = PersianCalendar.GetYear(dateTime);
        var num = year / 100 * 100;
         
        return (year - num).ToString("d2") + "/" + month.ToString("d2") + "/" + dayOfMonth.ToString("d2");
    }

    public static string GetHijriTimeString(this DateTime dateTime)
    {
        var timeOfDay = dateTime.TimeOfDay;
          
        return timeOfDay.Hours.ToString("d2") + ":" + timeOfDay.Minutes.ToString("d2");
    }

    public static string GetHijriFullTimeString(this DateTime dateTime)
    {
        var timeOfDay = dateTime.TimeOfDay;
           
        return timeOfDay.Hours.ToString("d2") + ":" + timeOfDay.Minutes.ToString("d2") +
               string.Format("{0}:{1}:{2:d2}", timeOfDay.Hours, timeOfDay.Minutes, timeOfDay.Seconds);
    }

    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public static string GetHijriDayNameString(this DateTime dateTime)
    {
        switch (dateTime.DayOfWeek)
        {
            case DayOfWeek.Sunday:
                return "یکشنبه";
            case DayOfWeek.Monday:
                return "دوشنبه";
            case DayOfWeek.Tuesday:
                return "سه شنبه";
            case DayOfWeek.Wednesday:
                return "چهارشنبه";
            case DayOfWeek.Thursday:
                return "پنج شنبه";
            case DayOfWeek.Friday:
                return "جمعه";
            case DayOfWeek.Saturday:
                return "شنبه";
            default:
                return "";
        }
    }

    public static string GetHijriDateTimeString(this DateTime dateTime)
    {
        return dateTime.GetHijriDateString() + " " + dateTime.GetHijriTimeString();
    }
}