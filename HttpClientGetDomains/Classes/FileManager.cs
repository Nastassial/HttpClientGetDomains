
namespace HttpClientGetDomains.Classes;

internal class FileManager
{
    private static readonly string _pathDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "../../../";
    
    private string _filePath = Path.Combine(_pathDirectory, "Data/");

    public string? FileName { get; set; }

    public FileManager() { }

    public FileManager(string fileName)
    {
        FileName = fileName;
    }

    public FileManager(string filePath, string fileName) : this(fileName)
    {
        _filePath = filePath;
    }

    public void Write(string text)
    {
        File.WriteAllText(_filePath + FileName, text);
    }
}
