using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PenAndPaper.NUnit.HelpClasses
{
    internal class URLChecker
    {
        public static async Task<bool> ValidateHttpOrHttps(string uriName)
        {
            return await Task.Run(() => IsHttpOrHttps(uriName));
        }

        private static bool IsHttpOrHttps(string uriName)
        {
            return Uri.IsWellFormedUriString(uriName, UriKind.Absolute);
        }

        public static async Task<bool> UrlConnect(string url)
        {
            if (await ValidateHttpOrHttps(url))
            {
                return await Task.Run(() => IsResponseSuccessStatusCode(url));
            }
            return false;
        }

        private static bool IsResponseSuccessStatusCode(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 15000;
            request.Method = "HEAD"; // As per Lasse's comment
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }

        private static async Task<bool> UrlExsists(string url)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequestMsg = new HttpRequestMessage(HttpMethod.Head, url);
            HttpResponseMessage response = await client.SendAsync(httpRequestMsg);
            return response.IsSuccessStatusCode;
        }
    }
}
