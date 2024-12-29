using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;

public class JwtAccessTokenProvider : IAccessTokenProvider
{
    public AllowedHostsValidator AllowedHostsValidator { get; }

    private string _jwtToken;

    public JwtAccessTokenProvider()
    {
        AllowedHostsValidator = new AllowedHostsValidator();  // Optional, use as needed
        _jwtToken = LoadJwtTokenFromSettings();
    }

    public async Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
    {
        // Return the loaded JWT token
        return _jwtToken;
    }

    private string LoadJwtTokenFromSettings()
    {
        try
        {
            // Path to your settings.json file
            var settingsFilePath = "trisatenergy_api_geosphere/settings.json";  // Update with your actual file path

            // Read the JSON file
            string jsonString = File.ReadAllText(settingsFilePath);

            // Parse the JSON file
            var jsonDocument = JsonDocument.Parse(jsonString);

            // Extract the JWT token from the JSON structure
            var jwtToken = jsonDocument.RootElement
                .GetProperty("AppSettings")
                .GetProperty("JwtToken")
                .GetString();

            return jwtToken ?? throw new Exception("JWT Token not found in settings.json");
        }
        catch (Exception ex)
        {
            // Log the error and rethrow
            Console.WriteLine($"Error loading JWT token: {ex.Message}");
            throw;
        }
    }
}