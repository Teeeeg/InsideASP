using Microsoft.Extensions.Configuration;
using OptionSystem.CustomOptions;

namespace OptionSystem.Apps;

public class Tester9
{
    public static void Run()
    {
        var root = new ConfigurationBuilder()
            .AddJsonFile("Properties/profile.json")
            .Build();

        var profile = root.Get<Profile>();
        
        Console.WriteLine($"Gender: {profile.Gender}");
        Console.WriteLine($"Age: {profile.Age}");
        Console.WriteLine($"Email Address: {profile.ContactInfo.EmailAddress}");
        Console.WriteLine($"Phone No: {profile.ContactInfo.PhoneNo}");
    }
}