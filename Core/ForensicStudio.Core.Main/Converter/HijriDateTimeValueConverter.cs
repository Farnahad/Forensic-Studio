using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using ForensicStudio.Core.Main.HijriDateTime;

namespace ForensicStudio.Core.Main.Converter;

public class HijriDateTimeValueConverter : MarkupExtension, IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime dateTime)
            return dateTime.GetHijriDateTimeString();

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}