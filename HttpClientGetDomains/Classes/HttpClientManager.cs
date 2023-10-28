namespace HttpClientGetDomains.Classes;

internal class HttpClientManager
{
    private readonly HttpClient _httpClient = new HttpClient();

    private string _url { get; }

    public HttpClientManager(string url) 
    {
        _url = url;
    }

    public async Task<string> GetContent()
    {
        HttpResponseMessage httpResponse = await _httpClient.GetAsync(_url);

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
