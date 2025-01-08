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
namespace ApiSdk.Station.Item.Item.Filter
{
    /// <summary>
    /// Builds and executes requests for operations under \station\{mode}\{resource_id}\filter
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class FilterRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public FilterRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/station/{mode}/{resource_id}/filter{?end_date*,has_global_radiation*,has_sunshine*,id*,is_active*,max_altitude*,min_altitude*,name*,start_date*,state*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public FilterRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/station/{mode}/{resource_id}/filter{?end_date*,has_global_radiation*,has_sunshine*,id*,is_active*,max_altitude*,min_altitude*,name*,start_date*,state*}", rawUrl)
        {
        }
        /// <summary>
        /// Filter Stations
        /// </summary>
        /// <returns>A <see cref="global::ApiSdk.Models.StationFilterResponseDto"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::ApiSdk.Models.HTTPValidationError">When receiving a 422 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::ApiSdk.Models.StationFilterResponseDto?> GetAsync(Action<RequestConfiguration<global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder.FilterRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::ApiSdk.Models.StationFilterResponseDto> GetAsync(Action<RequestConfiguration<global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder.FilterRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "422", global::ApiSdk.Models.HTTPValidationError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::ApiSdk.Models.StationFilterResponseDto>(requestInfo, global::ApiSdk.Models.StationFilterResponseDto.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Filter Stations
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder.FilterRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder.FilterRequestBuilderGetQueryParameters>> requestConfiguration = default)
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
        /// <returns>A <see cref="global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder WithUrl(string rawUrl)
        {
            return new global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Filter Stations
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class FilterRequestBuilderGetQueryParameters 
        {
            /// <summary>Supply in format: *YYYY-MM-DD* or *YYYY-MM-DDTHH:mm*</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("end_date")]
            public string? EndDate { get; set; }
#nullable restore
#else
            [QueryParameter("end_date")]
            public string EndDate { get; set; }
#endif
            [QueryParameter("has_global_radiation")]
            public bool? HasGlobalRadiation { get; set; }
            [QueryParameter("has_sunshine")]
            public bool? HasSunshine { get; set; }
            /// <summary>Restricts output to stations that have one of the given ids.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("id")]
            public string[]? Id { get; set; }
#nullable restore
#else
            [QueryParameter("id")]
            public string[] Id { get; set; }
#endif
            [QueryParameter("is_active")]
            public bool? IsActive { get; set; }
            /// <summary>Physical unit is *m*</summary>
            [QueryParameter("max_altitude")]
            public int? MaxAltitude { get; set; }
            /// <summary>Physical unit is *m*</summary>
            [QueryParameter("min_altitude")]
            public int? MinAltitude { get; set; }
            /// <summary>Restricts output to stations whose name contains one of the given strings.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("name")]
            public string[]? Name { get; set; }
#nullable restore
#else
            [QueryParameter("name")]
            public string[] Name { get; set; }
#endif
            /// <summary>Supply in format: *YYYY-MM-DD* or *YYYY-MM-DDTHH:mm*</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("start_date")]
            public string? StartDate { get; set; }
#nullable restore
#else
            [QueryParameter("start_date")]
            public string StartDate { get; set; }
#endif
            /// <summary>Restricts output to stations who are located in one of the given states</summary>
            [Obsolete("This property is deprecated, use StateAsBundesland instead")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("state")]
            public string[]? State { get; set; }
#nullable restore
#else
            [QueryParameter("state")]
            public string[] State { get; set; }
#endif
            /// <summary>Restricts output to stations who are located in one of the given states</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("state")]
            public global::ApiSdk.Models.Bundesland[]? StateAsBundesland { get; set; }
#nullable restore
#else
            [QueryParameter("state")]
            public global::ApiSdk.Models.Bundesland[] StateAsBundesland { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
        public partial class FilterRequestBuilderGetRequestConfiguration : RequestConfiguration<global::ApiSdk.Station.Item.Item.Filter.FilterRequestBuilder.FilterRequestBuilderGetQueryParameters>
        {
        }
    }
}
#pragma warning restore CS0618