using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using OptionSystem.CustomOptions;

namespace OptionSystem.Apps;

public class Tester7
{
    public static void Run()
    {
        var source = new Dictionary<string, string>
        {
            ["point"] = "(123, 456)"
        };

        var root = new ConfigurationBuilder()
            .AddInMemoryCollection(source)
            .Build();

        var point = root.GetValue<Point>("point");

        Debug.Assert(point.X == 123);
        Console.WriteLine(point);
    }
}