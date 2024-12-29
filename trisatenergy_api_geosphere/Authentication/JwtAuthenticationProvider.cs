using Microsoft.Kiota.Abstractions;
using System;
using System.Text.Json;
using Microsoft.Kiota.Abstractions.Authentication;

namespace trisatenergy_api_geosphere.Authentication
{
 
    public class JwtAuthenticationProvider : IAuthenticationProvider
    {
        private readonly string _jwtToken;

        public JwtAuthenticationProvider(string jwtToken)
        {
            _jwtToken = jwtToken ?? throw new ArgumentNullException(nameof(jwtToken), "JWT token must not be null.");
        }

        public async Task AuthenticateRequestAsync(RequestInformation request, CancellationToken cancellationToken)
        {
            // Ensure cancellation support
            cancellationToken.ThrowIfCancellationRequested();

            // Attach the JWT token to the Authorization header of the request
            request.Headers["Authorization"] = $"Bearer {_jwtToken}";

            // Optionally, you could add additional request modifications here.
            await Task.CompletedTask;  // Ensure this is an async method even if it's not doing async work now.
        }
    }

}

