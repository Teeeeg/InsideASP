using Microsoft.Extensions.Configuration;

namespace OptionSystem.Apps;

public class Tester1
{
    public static void Run()
    {
        var initialData = new Dictionary<string, string>
        {
            ["longDatePattern"] = "dddd, MMMM d, yyyy",
            ["longTimePattern"] = "h:mm:ss tt",
            ["shortDatePattern"] = "M/d/yyyy",
            ["shortTimePattern"] = "h:mm tt"
        };

        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(initialData)
            .Build();

        // var options = new DateTimeFormatOptions(config);
        // Console.WriteLine($"LongDatePattern: {options.LongDatePattern}");
        // Console.WriteLine($"LongTimePattern: {options.LongTimePattern}");
        // Console.WriteLine($"ShortDatePattern: {options.ShortDatePattern}");
        // Console.WriteLine($"ShortTimePattern: {options.ShortTimePattern}");
    }
}