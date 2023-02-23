using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace OptionSystem.Apps;

public class Tester6
{
    public static void Run()
    {
        var source = new Dictionary<string, string>
        {
            ["foo"] = null,
            ["bar"] = "",
            ["baz"] = "123"
        };

        var root = new ConfigurationBuilder()
            .AddInMemoryCollection(source)
            .Build();

        Debug.Assert(root.GetValue<object>("foo") == null);
        Debug.Assert("".Equals(root.GetValue<object>("bar")));
        Debug.Assert("123".Equals(root.GetValue<object>("baz")));

        //针对普通类型
        Debug.Assert(root.GetValue<int>("foo") == 0);
        Debug.Assert(root.GetValue<int>("baz") == 123);

        //针对Nullable<T>
        Debug.Assert(root.GetValue<int?>("foo") == null);
        Debug.Assert(root.GetValue<int?>("bar") == null);
    }
}