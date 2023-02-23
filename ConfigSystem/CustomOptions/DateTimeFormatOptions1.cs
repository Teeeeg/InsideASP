namespace OptionSystem.CustomOptions;

public class DateTimeFormatOptions1
{
    public string DatePattern { get; set; }
    public string TimePattern { get; set; }
    public override string? ToString() => $"Date: {DatePattern}; Time: {TimePattern}";

}