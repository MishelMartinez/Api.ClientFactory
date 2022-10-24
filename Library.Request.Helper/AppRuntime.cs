using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Library.Request.Helper
{
    public class AppRuntime
    {
        private static IServiceProvider serviceProvider { get; set; }

        public static IHttpClientFactory HttpClientFactory
        {
            get
            {
                if (serviceProvider == null)
                {

                    
                    Microsoft.Extensions.Hosting.IHostBuilder builder = Host.CreateDefaultBuilder();
                    builder.ConfigureServices(services =>
                    {
                        services.AddHttpClient("MyCloudSchool", config =>
                        {
                            config.BaseAddress = new Uri("https://localhost:7244");
                            
                        });
                        services.AddHttpClient("client_2", config =>
                        {
                            config.BaseAddress = new Uri("http://client_2.com");
                            config.DefaultRequestHeaders.Add("header_2", "header_2");
                        });
                    });
                    serviceProvider = builder.Build().Services;
                }

                return (IHttpClientFactory)serviceProvider.GetServices<IHttpClientFactory>().First();
            }
        }

    }
}


