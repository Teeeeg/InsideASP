using System.Text;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace FS.InsideFS;

public class FileWatch
{
    public static async void Test()
    {
        using (var fileProvider = new PhysicalFileProvider(@"/Users/taoyupeng/On My Mac/Repo/InsideASP/FileSystem/"))
        {
            string original = null;
            ChangeToken.OnChange(() => fileProvider.Watch("data.txt"), Callback);
            while (true)
            {
                File.AppendAllText("/Users/taoyupeng/On My Mac/Repo/InsideASP/FileSystem/data.txt",
                    DateTime.Now.ToString() + '\n');
                await Task.Delay(5000);
            }

            async void Callback()
            {
                var stream = fileProvider.GetFileInfo("data.txt").CreateReadStream();
                {
                    var buffer = new byte[stream.Length];
                    await stream.ReadAsync(buffer, 0, buffer.Length);
                    var current = Encoding.Default.GetString(buffer);
                    if (current != original) Console.WriteLine(original = current);
                }
            }
        }
    }
}