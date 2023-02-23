using FS.InsideFS;

// var provider = new ServiceCollection()
//     .AddSingleton<IFileProvider>(new PhysicalFileProvider(@"/Users/taoyupeng/On My Mac/Repo/InsideASP"))
//     .AddSingleton<IFileManager, FileManager>()
//     .BuildServiceProvider();
//
// var allText = await provider.GetRequiredService<IFileManager>().ReadAllTextAsync("AspPlayground/appsettings.json");

FileWatch.Test();
Thread.Sleep(20000);