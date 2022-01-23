using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;

namespace AspnetRunBasics.Extensions
{
    public static class HttpClientPollyExtensions
    {
        /// <summary>
        /// Use Retry Policy - Using Polly
        /// </summary>
        /// <param name="httpClientBuilder"></param>
        /// <returns></returns>
        public static IHttpClientBuilder UseRetryPolicy(this IHttpClientBuilder httpClientBuilder)
        {
            return httpClientBuilder.AddPolicyHandler(GetRetryPolicy());
        }

        /// <summary>
        /// Retry policy definition
        /// </summary>
        /// <returns></returns>
        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}