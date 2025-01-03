using ApiSdk;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using trisatenergy_api_geosphere;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace trisatenergy_api_geosphere
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true; // Prevent immediate termination
                cancellationTokenSource.Cancel();
            };
            
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("settings.json", false, true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<AppSettings>(context.Configuration.GetSection(nameof(AppSettings)));
                    services.AddLogging(builder =>
                    {
                        builder.AddConfiguration(context.Configuration.GetSection("AppSettings:Logging"));
                        builder.AddConsole();
                    });
                    services.AddSingleton(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);
                    services.AddSingleton<IAuthenticationProvider, AnonymousAuthenticationProvider>();
                    services.AddSingleton<IRequestAdapter, HttpClientRequestAdapter>();
                    services.AddSingleton<GeoSphereApiClient>();
                })
                .Build();

            using IServiceScope scope = host.Services.CreateScope();
            var appSettings = scope.ServiceProvider.GetRequiredService<AppSettings>();
            var authProvider = scope.ServiceProvider.GetRequiredService<IAuthenticationProvider>();
            var adapter = scope.ServiceProvider.GetRequiredService<IRequestAdapter>();
            var geoSphereClient = scope.ServiceProvider.GetRequiredService<GeoSphereApiClient>();
            // Start the application
            Task geoSphereClientTask = geoSphereClient.Start();
            // Wait for the application to complete or the shutdown signal
            await Task.WhenAny(geoSphereClientTask, Task.Delay(Timeout.Infinite, cancellationTokenSource.Token));
            
        }
    }
}