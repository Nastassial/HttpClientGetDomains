namespace HttpClientGetDomains.Classes;

internal class HttpClientManager
{
    private readonly HttpClient _httpClient = new HttpClient();

    private readonly string _url;

    public string Url { get { return _url; } }

    public HttpClientManager(string url) 
    {
        _url = url;
    }

    public async Task<string> GetContent()
    {
        HttpResponseMessage httpResponse = await _httpClient.GetAsync(Url);

        if (httpResponse.IsSuccessStatusCode)
        {
            string htmlContent = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(htmlContent))
            {
                return htmlContent;
            }
        }

        return null;
    }
}
