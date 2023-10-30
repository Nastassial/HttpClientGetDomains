namespace HttpClientGetDomains.Classes;

internal static class HttpClientManager
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public static async Task<string> GetContent(string url)
    {
        HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);

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
