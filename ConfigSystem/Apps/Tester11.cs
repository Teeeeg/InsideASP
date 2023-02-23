using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using OptionSystem.CustomOptions;

namespace OptionSystem.Apps;

public class Tester11
{
    public static void Run()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(path: "Properties/profile.json", optional: false, reloadOnChange: true)
            .Build();

        ChangeToken.OnChange(
            () => configuration.GetReloadToken(),
            () => Console.WriteLine("Reloaded"));

        var provider = new ServiceCollection()
            .AddOptions()
            .Configure<Profile>(configuration)
            .BuildServiceProvider();

        var monitor = provider.GetRequiredService<IOptionsMonitor<Profile>>();     
        var profile = monitor.CurrentValue;
        
        Console.WriteLine($"Gender: {profile.Gender}");
        Console.WriteLine($"Age: {profile.Age}");
        Console.WriteLine($"Email Address: {profile.ContactInfo.EmailAddress}");
        Console.WriteLine($"Phone No: {profile.ContactInfo.PhoneNo}\n");

        monitor.OnChange(
            profile =>
            {
                Console.WriteLine($"Gender: {profile.Gender}");
                Console.WriteLine($"Age: {profile.Age}");
                Console.WriteLine($"Email Address: {profile.ContactInfo.EmailAddress}");
                Console.WriteLine($"Phone No: {profile.ContactInfo.PhoneNo}\n");
            });
        
        Console.Read();
    }
}