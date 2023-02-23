using Microsoft.Extensions.Configuration;
using OptionSystem.CustomOptions;

namespace OptionSystem.Apps;

public class Tester4
{
    public static void Run()
    {
        var format = new ConfigurationBuilder()
            .AddJsonFile("Properties/appsettings.json")
            .Build()
            .GetSection("format")
            .Get<FormatOptions>();


        var dateTime = format.DateTime;
        var currencyDecimal = format.CurrencyDecimal;

        Console.WriteLine("DateTime:");
        Console.WriteLine($"\tLongDatePattern: {dateTime.LongDatePattern}");
        Console.WriteLine($"\tLongTimePattern: {dateTime.LongTimePattern}");
        Console.WriteLine($"\tShortDatePattern: {dateTime.ShortDatePattern}");
        Console.WriteLine($"\tShortTimePattern: {dateTime.ShortTimePattern}");

        Console.WriteLine("CurrencyDecimal:");
        Console.WriteLine($"\tDigits:{currencyDecimal.Digits}");
        Console.WriteLine($"\tSymbol:{currencyDecimal.Symbol}");
    }
}