using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DiagnosticSystem.Apps;

public class Tester1
{
    public static void Run()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder =>
                builder.AddDebug()
                    .AddDebug()
                    .AddConsole())
            .BuildServiceProvider();

        var logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("Tester1");
        var levels = Enum.GetValues<LogLevel>();
        var eventId = 1;

        levels = levels.Where(item => item != LogLevel.None).ToArray();

        Array.ForEach(levels, level => { logger.Log(level, eventId++, $"This is a/an {level}"); });
    }
}