// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace ApiSdk.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class GridForecastMetadataModel : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The available_forecast_reftimes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<DateTimeOffset?>? AvailableForecastReftimes { get; set; }
#nullable restore
#else
        public List<DateTimeOffset?> AvailableForecastReftimes { get; set; }
#endif
        /// <summary>The bbox property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<double?>? Bbox { get; set; }
#nullable restore
#else
        public List<double?> Bbox { get; set; }
#endif
        /// <summary>The bbox_outer property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<double?>? BboxOuter { get; set; }
#nullable restore
#else
        public List<double?> BboxOuter { get; set; }
#endif
        /// <summary>The crs property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Crs { get; set; }
#nullable restore
#else
        public string Crs { get; set; }
#endif
        /// <summary>The forecast_length property</summary>
        public int? ForecastLength { get; set; }
        /// <summary>The frequency property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Frequency { get; set; }
#nullable restore
#else
        public string Frequency { get; set; }
#endif
        /// <summary>The grid_bounds property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<double?>? GridBounds { get; set; }
#nullable restore
#else
        public List<double?> GridBounds { get; set; }
#endif
        /// <summary>The last_forecast_reftime property</summary>
        public DateTimeOffset? LastForecastReftime { get; set; }
        /// <summary>The max_forecast_offset property</summary>
        public int? MaxForecastOffset { get; set; }
        /// <summary>The mode property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Mode { get; set; }
#nullable restore
#else
        public string Mode { get; set; }
#endif
        /// <summary>The parameters property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::ApiSdk.Models.ParameterMetadataModel>? Parameters { get; set; }
#nullable restore
#else
        public List<global::ApiSdk.Models.ParameterMetadataModel> Parameters { get; set; }
#endif
        /// <summary>The response_formats property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? ResponseFormats { get; set; }
#nullable restore
#else
        public List<string> ResponseFormats { get; set; }
#endif
        /// <summary>The spatial_resolution_m property</summary>
        public int? SpatialResolutionM { get; set; }
        /// <summary>The title property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Title { get; set; }
#nullable restore
#else
        public string Title { get; set; }
#endif
        /// <summary>The type property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Type { get; set; }
#nullable restore
#else
        public string Type { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Models.GridForecastMetadataModel"/> and sets the default values.
        /// </summary>
        public GridForecastMetadataModel()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ApiSdk.Models.GridForecastMetadataModel"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ApiSdk.Models.GridForecastMetadataModel CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ApiSdk.Models.GridForecastMetadataModel();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "available_forecast_reftimes", n => { AvailableForecastReftimes = n.GetCollectionOfPrimitiveValues<DateTimeOffset?>()?.AsList(); } },
                { "bbox", n => { Bbox = n.GetCollectionOfPrimitiveValues<double?>()?.AsList(); } },
                { "bbox_outer", n => { BboxOuter = n.GetCollectionOfPrimitiveValues<double?>()?.AsList(); } },
                { "crs", n => { Crs = n.GetStringValue(); } },
                { "forecast_length", n => { ForecastLength = n.GetIntValue(); } },
                { "frequency", n => { Frequency = n.GetStringValue(); } },
                { "grid_bounds", n => { GridBounds = n.GetCollectionOfPrimitiveValues<double?>()?.AsList(); } },
                { "last_forecast_reftime", n => { LastForecastReftime = n.GetDateTimeOffsetValue(); } },
                { "max_forecast_offset", n => { MaxForecastOffset = n.GetIntValue(); } },
                { "mode", n => { Mode = n.GetStringValue(); } },
                { "parameters", n => { Parameters = n.GetCollectionOfObjectValues<global::ApiSdk.Models.ParameterMetadataModel>(global::ApiSdk.Models.ParameterMetadataModel.CreateFromDiscriminatorValue)?.AsList(); } },
                { "response_formats", n => { ResponseFormats = n.GetCollectionOfPrimitiveValues<string>()?.AsList(); } },
                { "spatial_resolution_m", n => { SpatialResolutionM = n.GetIntValue(); } },
                { "title", n => { Title = n.GetStringValue(); } },
                { "type", n => { Type = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<DateTimeOffset?>("available_forecast_reftimes", AvailableForecastReftimes);
            writer.WriteCollectionOfPrimitiveValues<double?>("bbox", Bbox);
            writer.WriteCollectionOfPrimitiveValues<double?>("bbox_outer", BboxOuter);
            writer.WriteStringValue("crs", Crs);
            writer.WriteIntValue("forecast_length", ForecastLength);
            writer.WriteStringValue("frequency", Frequency);
            writer.WriteCollectionOfPrimitiveValues<double?>("grid_bounds", GridBounds);
            writer.WriteDateTimeOffsetValue("last_forecast_reftime", LastForecastReftime);
            writer.WriteIntValue("max_forecast_offset", MaxForecastOffset);
            writer.WriteStringValue("mode", Mode);
            writer.WriteCollectionOfObjectValues<global::ApiSdk.Models.ParameterMetadataModel>("parameters", Parameters);
            writer.WriteCollectionOfPrimitiveValues<string>("response_formats", ResponseFormats);
            writer.WriteIntValue("spatial_resolution_m", SpatialResolutionM);
            writer.WriteStringValue("title", Title);
            writer.WriteStringValue("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
