using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OptionSystem.CustomOptions;

namespace OptionSystem.Apps;

public class Tester10
{
    public static void Run()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("Properties/profile1.json")
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddOptions()
            .Configure<Profile>("foo", configuration.GetSection("foo"))
            .Configure<Profile>("bar", configuration.GetSection("bar"))
            .BuildServiceProvider();

        var options = serviceProvider.GetRequiredService<IOptionsSnapshot<Profile>>();

        void Print(Profile profile)
        {
            Console.WriteLine($"Gender: {profile.Gender}");
            Console.WriteLine($"Age: {profile.Age}");
            Console.WriteLine($"Email Address: {profile.ContactInfo.EmailAddress}");
            Console.WriteLine($"Phone No: {profile.ContactInfo.PhoneNo}\n");
        }
        
        Print(options.Get("foo"));
        Print(options.Get("bar"));
    }
}
