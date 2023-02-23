using System.ComponentModel;

namespace OptionSystem.CustomOptions;

[TypeConverter(typeof(PointTypeConverter))]
public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public override string ToString()
    {
        return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
    }
}