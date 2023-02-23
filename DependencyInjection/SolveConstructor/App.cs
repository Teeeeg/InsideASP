using Microsoft.Extensions.DependencyInjection;

namespace RawFramework.SolveConstructor;

public class App
{
    public static void Run()
    {
        new ServiceCollection()
            .AddTransient<IFoo, Foo>()
            .AddTransient<IBar, Bar>()
            .AddTransient<IQux, Qux>()
            .BuildServiceProvider()
            .GetService<IQux>();
    }
}