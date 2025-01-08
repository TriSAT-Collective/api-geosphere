// <auto-generated/>
#pragma warning disable CS0618
using ApiSdk.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ApiSdk.Grid.Historical.Item.Metadata.Parameters
{
    /// <summary>
    /// Builds and executes requests for operations under \grid\historical\{resource_id}\metadata\parameters
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class ParametersRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ParametersRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/grid/historical/{resource_id}/metadata/parameters{?filename*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public ParametersRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/grid/historical/{resource_id}/metadata/parameters{?filename*}", rawUrl)
        {
        }
        /// <summary>
        /// Historical Grid Parameter Metadata Csv
        /// </summary>
        /// <returns>A <see cref="UntypedNode"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::ApiSdk.Models.HTTPValidationError">When receiving a 422 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<UntypedNode?> GetAsync(Action<RequestConfiguration<global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder.ParametersRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<UntypedNode> GetAsync(Action<RequestConfiguration<global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder.ParametersRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "422", global::ApiSdk.Models.HTTPValidationError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<UntypedNode>(requestInfo, UntypedNode.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Historical Grid Parameter Metadata Csv
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder.ParametersRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder.ParametersRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder WithUrl(string rawUrl)
        {
            return new global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Historical Grid Parameter Metadata Csv
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class ParametersRequestBuilderGetQueryParameters 
        {
            /// <summary>Filename without file extension</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("filename")]
            public string? Filename { get; set; }
#nullable restore
#else
            [QueryParameter("filename")]
            public string Filename { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class ParametersRequestBuilderGetRequestConfiguration : RequestConfiguration<global::ApiSdk.Grid.Historical.Item.Metadata.Parameters.ParametersRequestBuilder.ParametersRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618