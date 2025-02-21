// <auto-generated/>
#pragma warning disable CS0618
using ApiSdk.Datasets;
using ApiSdk.Grid;
using ApiSdk.Station;
using ApiSdk.Timeseries;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Serialization.Form;
using Microsoft.Kiota.Serialization.Json;
using Microsoft.Kiota.Serialization.Multipart;
using Microsoft.Kiota.Serialization.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using trisatenergy_api_geosphere;
using MongoDB.Driver;

namespace ApiSdk
{
    /// <summary>
    /// The main entry point of the SDK, exposes the configuration and the fluent API.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class GeoSphereApiClient : BaseRequestBuilder
    {
        /// <summary>The datasets property</summary>
        public global::ApiSdk.Datasets.DatasetsRequestBuilder Datasets
        {
            get => new global::ApiSdk.Datasets.DatasetsRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The grid property</summary>
        public global::ApiSdk.Grid.GridRequestBuilder Grid
        {
            get => new global::ApiSdk.Grid.GridRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The station property</summary>
        public global::ApiSdk.Station.StationRequestBuilder Station
        {
            get => new global::ApiSdk.Station.StationRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The timeseries property</summary>
        public global::ApiSdk.Timeseries.TimeseriesRequestBuilder Timeseries
        {
            get => new global::ApiSdk.Timeseries.TimeseriesRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.GeoSphereApiClient"/> and sets the default values.
        /// </summary>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GeoSphereApiClient(IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}", new Dictionary<string, object>())
        {
            ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<TextSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<FormSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultSerializer<MultipartSerializationWriterFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<TextParseNodeFactory>();
            ApiClientBuilder.RegisterDefaultDeserializer<FormParseNodeFactory>();
            if (string.IsNullOrEmpty(RequestAdapter.BaseUrl))
            {
                RequestAdapter.BaseUrl = "https://dataset.api.hub.geosphere.at/v1";
            }
            PathParameters.TryAdd("baseurl", RequestAdapter.BaseUrl);
        }
    }
}
#pragma warning restore CS0618