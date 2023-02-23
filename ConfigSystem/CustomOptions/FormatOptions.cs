namespace OptionSystem.CustomOptions;

public class FormatOptions
{
    // public FormatOptions(IConfiguration config)
    // {
    //     DateTime = new DateTimeFormatOptions(config.GetSection("DateTime"));
    //     CurrencyDecimal = new CurrencyDecimalFormatOptions(config.GetSection("CurrencyDecimal"));
    // }

    public DateTimeFormatOptions DateTime { get; set; }
    public CurrencyDecimalFormatOptions CurrencyDecimal { get; set; }
}