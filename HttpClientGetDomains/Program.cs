using HttpClientGetDomains.Classes;

int domainPagesCnt = 0;
const string url = "https://ru.wikipedia.org/wiki/";

FileManager fileManager = new FileManager();

char[] letters = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray(); // sequence "abcdefghijklmnopqrstuvwxyz"

foreach (char i in letters)
{
    foreach (char j in letters)
    {
        string domain = $".{i}{j}";

        string content = HttpClientManager.GetContent($"{url}{domain}").Result;

        if (!string.IsNullOrEmpty(content))
        {
            Console.WriteLine(domain);

            fileManager.FileName = $"{domain}.html";
            fileManager.Write(content);

            domainPagesCnt++;
        }
    }
}

Console.WriteLine($"Count of html pages - {domainPagesCnt}");
