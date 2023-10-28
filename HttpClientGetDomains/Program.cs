using System.Text;

string pathDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "../../../";
string filePath = Path.Combine(pathDirectory, "Data/htmlDomainPages.txt");
//string filePath = Path.Combine(pathDirectory, "Data/");

if (File.Exists(filePath))
{
    File.Delete(filePath);
}

int domainPagesCnt = 0;

StringBuilder domain = new StringBuilder();

const string url = "https://ru.wikipedia.org/wiki/";

char[] letters = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray(); // sequence "abcdefghijklmnopqrstuvwxyz"

for (int i = 0; i < letters.Length; i++)
{
    for (int j = 0; j < letters.Length; j++)
    {
        domain.Clear().Append('.').Append(letters[i]).Append(letters[j]);

        HttpClient client = new HttpClient();

        HttpResponseMessage httpResponse = await client.GetAsync($"{url}{domain}");

        if (httpResponse.IsSuccessStatusCode)
        {
            Console.WriteLine(domain.ToString());
            
            string htmlContent = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(htmlContent))
            {
                File.AppendAllText(filePath, $"\n\n--- PAGE FOR DOMAIN {domain} ---\n\n" + htmlContent);

                //File.WriteAllText(filePath + $"{domain}.html", htmlContent);
            }

            domainPagesCnt++;
        }
    }
}

Console.WriteLine($"Number of html pages - {domainPagesCnt}");
