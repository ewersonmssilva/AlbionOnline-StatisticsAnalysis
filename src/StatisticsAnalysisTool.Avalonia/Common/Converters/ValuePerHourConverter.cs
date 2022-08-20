using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace StatisticsAnalysisTool.Avalonia.Common.Converters;

public class ValuePerHourConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return $"{value ?? 0:N0} /h".ToString(CultureInfo.CurrentCulture);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}