using ForensicStudio.Core.Main.HijriDateTime;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ForensicStudio.Core.Main.Converter;

public class HijriDateValueConverter : MarkupExtension, IValueConverter
{
    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime dateTime)
            return dateTime.GetHijriDateString();

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        // {Binding IsMale, Converter={local:HijriDateValueConverter}}
        return this;
    }
}