using System.ComponentModel;
using System.Globalization;

namespace OptionSystem.CustomOptions;

public class PointTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        return sourceType == typeof(string);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        var splits = value.ToString().Split(',');
        var x = double.Parse(splits[0].Trim().TrimStart('('));
        var y = double.Parse(splits[1].Trim().TrimEnd(')'));
        return new Point { X = x, Y = y };
    }
}