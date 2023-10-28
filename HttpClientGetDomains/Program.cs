using System.Text;
using HttpClientGetDomains.Classes;

int domainPagesCnt = 0;
const string url = "https://ru.wikipedia.org/wiki/";

FileManager fileManager = new FileManager();
 
StringBuilder domain = new StringBuilder();

char[] letters = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray(); // sequence "abcdefghijklmnopqrstuvwxyz"

for (int i = 0; i < letters.Length; i++)
{
    for (int j = 0; j < letters.Length; j++)
    {
        domain.Clear().Append('.').Append(letters[i]).Append(letters[j]);

        HttpClientManager httpClientManager = new HttpClientManager($"{url}{domain}");

        string content = httpClientManager.GetContent().Result;

        if (!string.IsNullOrEmpty(content))
        {
            Console.WriteLine(domain.ToString());

            fileManager.FileName = domain.ToString() + ".html";
            fileManager.Write(content);

            domainPagesCnt++;
        }
    }
}

Console.WriteLine($"Count of html pages - {domainPagesCnt}");
