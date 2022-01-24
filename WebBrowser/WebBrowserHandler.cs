using HtmlAgilityPack;

namespace WebBrowser
{
    public class WebBrowserHandler
    {
        readonly static HttpClient client = new();

        /// <summary>
        /// Used to get raw html from url
        /// </summary>
        public static async Task<string> GetRawHtml(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Used to get html document object from url
        /// </summary>
        public static async Task<HtmlDocument> GetHtmlDocument(string url)
        {
            string html = await GetRawHtml(url);

            HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(html);
            return htmlDocument;
        }
    }
}