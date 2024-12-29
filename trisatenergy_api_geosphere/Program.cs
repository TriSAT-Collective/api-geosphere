using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiSdk;
using trisatenergy_api_geosphere.Authentication;

namespace trisatenergy_api_geosphere
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Load configuration settings, including the JWT token
                    config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);
                })
                .ConfigureServices((context, services) =>
                {
                    // Retrieve JWT token from settings.json
                    string jwtToken = context.Configuration["AppSettings:JwtToken"];
                    
                    // Register JwtAuthenticationProvider with the token
                    services.AddSingleton<IAuthenticationProvider>(new JwtAuthenticationProvider(jwtToken));

                    // Register the HttpClient and a custom API client
                    services.AddHttpClient();  // Registers IHttpClientFactory

                    services.AddSingleton<ApiClient>(sp =>
                    {
                        var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
                        var httpClient = clientFactory.CreateClient(); // Create HttpClient instance
                        var authProvider = sp.GetRequiredService<IAuthenticationProvider>();
                        return new ApiClient(httpClient, authProvider); // Pass HttpClient and auth provider to the custom API client
                    });

                    // Optionally, add logging and other services if necessary
                    services.AddLogging();
                })
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var apiClient = scope.ServiceProvider.GetRequiredService<ApiClient>();

                // Now you can use the ApiClient for API calls
                // Example: await apiClient.CallSomeApiMethodAsync();
            }
        }
    }
}
