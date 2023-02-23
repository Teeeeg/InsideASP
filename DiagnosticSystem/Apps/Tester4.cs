using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DiagnosticSystem.Apps;

public class Tester4
{
    public static void Run()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder
                    .SetMinimumLevel(LogLevel.Warning)
                    .AddConsole())
            .BuildServiceProvider();

        var logger = serviceProvider.GetRequiredService<ILogger<Tester4>>();
        var levels = Enum.GetValues<LogLevel>();
        levels = levels.Where(item => item != LogLevel.None).ToArray();
        var eventId = 1;
        
        Array.ForEach(levels, level => logger.Log(level, eventId++, $"This is a/an {level} log message."));
    }
}