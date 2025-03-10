// <auto-generated/>
#pragma warning disable CS0618
using ApiSdk.Models;
using ApiSdk.Station.Historical.Item.Metadata;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ApiSdk.Station.Historical.Item
{
    /// <summary>
    /// Builds and executes requests for operations under \station\historical\{resource_id}
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class WithResource_ItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>The metadata property</summary>
        public global::ApiSdk.Station.Historical.Item.Metadata.MetadataRequestBuilder Metadata
        {
            get => new global::ApiSdk.Station.Historical.Item.Metadata.MetadataRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithResource_ItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/station/historical/{resource_id}?end={end}&parameters={parameters}&start={start}&station_ids={station_ids}{&filename*,output_format*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithResource_ItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/station/historical/{resource_id}?end={end}&parameters={parameters}&start={start}&station_ids={station_ids}{&filename*,output_format*}", rawUrl)
        {
        }
        /// <summary>
        /// Historical Station Data
        /// </summary>
        /// <returns>A <see cref="global::ApiSdk.Models.StationGeoJSONSerializer"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::ApiSdk.Models.HTTPValidationError">When receiving a 422 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::ApiSdk.Models.StationGeoJSONSerializer?> GetAsync(Action<RequestConfiguration<global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder.WithResource_ItemRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::ApiSdk.Models.StationGeoJSONSerializer> GetAsync(Action<RequestConfiguration<global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder.WithResource_ItemRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "422", global::ApiSdk.Models.HTTPValidationError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::ApiSdk.Models.StationGeoJSONSerializer>(requestInfo, global::ApiSdk.Models.StationGeoJSONSerializer.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Historical Station Data
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder.WithResource_ItemRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder.WithResource_ItemRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder WithUrl(string rawUrl)
        {
            return new global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Historical Station Data
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class WithResource_ItemRequestBuilderGetQueryParameters 
        {
            /// <summary>Supply in format: *YYYY-MM-DDThh:mm*. Time is optional.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("end")]
            public string? End { get; set; }
#nullable restore
#else
            [QueryParameter("end")]
            public string End { get; set; }
#endif
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
            [Obsolete("This property is deprecated, use OutputFormatAsGetOutputFormatQueryParameterType instead")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("output_format")]
            public string? OutputFormat { get; set; }
#nullable restore
#else
            [QueryParameter("output_format")]
            public string OutputFormat { get; set; }
#endif
            [QueryParameter("output_format")]
            public global::ApiSdk.Station.Historical.Item.GetOutput_formatQueryParameterType? OutputFormatAsGetOutputFormatQueryParameterType { get; set; }
            /// <summary>At least one parameter has to be specified.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("parameters")]
            public string[]? Parameters { get; set; }
#nullable restore
#else
            [QueryParameter("parameters")]
            public string[] Parameters { get; set; }
#endif
            /// <summary>Supply in format: *YYYY-MM-DDThh:mm*. Time is optional.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("start")]
            public string? Start { get; set; }
#nullable restore
#else
            [QueryParameter("start")]
            public string Start { get; set; }
#endif
            /// <summary>At least one station id has to be specified.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("station_ids")]
            public string[]? StationIds { get; set; }
#nullable restore
#else
            [QueryParameter("station_ids")]
            public string[] StationIds { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class WithResource_ItemRequestBuilderGetRequestConfiguration : RequestConfiguration<global::ApiSdk.Station.Historical.Item.WithResource_ItemRequestBuilder.WithResource_ItemRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618
