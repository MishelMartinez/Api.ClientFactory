using System;
using System.Text.Json;

namespace Library.Request.Helper
{
    public static class HttpRequestHelper
    {
        public static async Task<T> GetMethod<T>(string clientName, string route)
        {
            var httpResponseMessage = await AppRuntime.HttpClientFactory
                                       .CreateClient(clientName)
                                       .GetAsync(route);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<T>(contentStream);
            }

            return default(T);
        }
    }
}

