namespace FS.InsideFS;

public interface IFileManager
{
    void ShowStructure(Action<int, string> render);
    Task<string> ReadAllTextAsync(string path);
}