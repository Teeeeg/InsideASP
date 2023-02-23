using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OptionSystem.CustomOptions;


namespace OptionSystem.Apps;

public class Tester8
{
    public static void Run()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("Properties/profile.json")
            .Build();

        var service = new ServiceCollection()
            .AddOptions()
            .Configure<Profile>(config)
            .BuildServiceProvider();

        var profile = service.GetRequiredService<IOptions<Profile>>().Value;

        Console.WriteLine($"Gender: {profile.Gender}");
        Console.WriteLine($"Age: {profile.Age}");
        Console.WriteLine($"Email Address: {profile.ContactInfo.EmailAddress}");
        Console.WriteLine($"Phone No: {profile.ContactInfo.PhoneNo}");

    }
}