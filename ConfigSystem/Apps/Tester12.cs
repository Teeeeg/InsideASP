using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;
using OptionSystem.CustomOptions;

namespace OptionSystem.Apps;

public class Tester12
{
    public static void Run(string[] args)
    {
        var environment = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build()["env"];

        var services = new ServiceCollection();
        services
            .AddSingleton<IHostEnvironment>(new HostingEnvironment { EnvironmentName = environment })
            .AddOptions<DateTimeFormatOptions1>()
            .Configure<IHostEnvironment>((options, hostEnvironment) =>
            {
                if (hostEnvironment.IsDevelopment())
                {
                    options.DatePattern = "dddd, MMMM d, yyyy";
                    options.TimePattern = "M/d/yyyy";
                }
                else
                {
                    options.DatePattern = "M/d/yyyy";
                    options.TimePattern = "h:mm tt";
                }
            });

        var serviceProvider = services.BuildServiceProvider();
        var format = serviceProvider.GetRequiredService<IOptions<DateTimeFormatOptions1>>().Value;

        Console.WriteLine(format);
    }
}