namespace OptionSystem.CustomOptions;

public class CurrencyDecimalFormatOptions
{
    // public CurrencyDecimalFormatOptions(IConfiguration config)
    // {
    //     Digits = int.Parse(config["Digits"]);
    //     Symbol = config["Symbol"];
    // }

    public int Digits { get; set; }
    public string Symbol { get; set; }
}