using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspnetRunBasics.Extensions
{
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Read content As <T> Async
        /// </summary>
        /// <param name="response"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> ReadContentAsAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode) throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        /// <summary>
        /// Post <T> as Json Async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpClient.PostAsync(url, content);
        }

        /// <summary>
        /// Put <T> as Json Async
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return httpClient.PutAsync(url, content);
        }
    }
}