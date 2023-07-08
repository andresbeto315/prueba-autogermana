using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace WebSite.Http
{
    public class HttpAPI
    {
        private HttpClient CreateCient(string certificate)
        {
            if (string.IsNullOrEmpty(certificate))
                return new HttpClient();

            // Agregar certificado seguridad bancolombia
            var xcertificate = new X509Certificate2(certificate, "");
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(xcertificate);
            return new HttpClient(handler);
        }

        private async Task<T?> Get<T>(string endpoint, string token, Dictionary<string, string> headers, Dictionary<string, string> parameters)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string queryString = string.Empty;
            foreach (var item in parameters)
            {
                if (string.IsNullOrEmpty(queryString))
                    queryString += $"?{item.Key}={item.Value}";
                else
                    queryString += $"&{item.Key}={item.Value}";
            }

            using var client = this.CreateCient(string.Empty);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage _httpResponse = await client.GetAsync($"{endpoint}{queryString}").ConfigureAwait(false);
            string? responseString = await _httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseString);
        }

        public async Task<T> Get<T>(string endpoint, Dictionary<string, string> headers, Dictionary<string, string> parameters)
        {
            return await this.Get<T>(endpoint, string.Empty, headers, parameters);
        }

        public async Task<T> Get<T>(string endpoint, string token, Dictionary<string, string> parameters)
        {
            return await this.Get<T>(endpoint, token, null, parameters);
        }
    }
}