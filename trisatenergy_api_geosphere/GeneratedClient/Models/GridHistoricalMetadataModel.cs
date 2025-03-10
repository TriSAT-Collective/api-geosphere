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
    public partial class GridHistoricalMetadataModel : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
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
        /// <summary>The end_time property</summary>
        public DateTimeOffset? EndTime { get; set; }
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
        /// <summary>The start_time property</summary>
        public DateTimeOffset? StartTime { get; set; }
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
        /// Instantiates a new <see cref="global::ApiSdk.Models.GridHistoricalMetadataModel"/> and sets the default values.
        /// </summary>
        public GridHistoricalMetadataModel()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::ApiSdk.Models.GridHistoricalMetadataModel"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::ApiSdk.Models.GridHistoricalMetadataModel CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::ApiSdk.Models.GridHistoricalMetadataModel();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "bbox", n => { Bbox = n.GetCollectionOfPrimitiveValues<double?>()?.AsList(); } },
                { "bbox_outer", n => { BboxOuter = n.GetCollectionOfPrimitiveValues<double?>()?.AsList(); } },
                { "crs", n => { Crs = n.GetStringValue(); } },
                { "end_time", n => { EndTime = n.GetDateTimeOffsetValue(); } },
                { "frequency", n => { Frequency = n.GetStringValue(); } },
                { "grid_bounds", n => { GridBounds = n.GetCollectionOfPrimitiveValues<double?>()?.AsList(); } },
                { "mode", n => { Mode = n.GetStringValue(); } },
                { "parameters", n => { Parameters = n.GetCollectionOfObjectValues<global::ApiSdk.Models.ParameterMetadataModel>(global::ApiSdk.Models.ParameterMetadataModel.CreateFromDiscriminatorValue)?.AsList(); } },
                { "response_formats", n => { ResponseFormats = n.GetCollectionOfPrimitiveValues<string>()?.AsList(); } },
                { "spatial_resolution_m", n => { SpatialResolutionM = n.GetIntValue(); } },
                { "start_time", n => { StartTime = n.GetDateTimeOffsetValue(); } },
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
            writer.WriteCollectionOfPrimitiveValues<double?>("bbox", Bbox);
            writer.WriteCollectionOfPrimitiveValues<double?>("bbox_outer", BboxOuter);
            writer.WriteStringValue("crs", Crs);
            writer.WriteDateTimeOffsetValue("end_time", EndTime);
            writer.WriteStringValue("frequency", Frequency);
            writer.WriteCollectionOfPrimitiveValues<double?>("grid_bounds", GridBounds);
            writer.WriteStringValue("mode", Mode);
            writer.WriteCollectionOfObjectValues<global::ApiSdk.Models.ParameterMetadataModel>("parameters", Parameters);
            writer.WriteCollectionOfPrimitiveValues<string>("response_formats", ResponseFormats);
            writer.WriteIntValue("spatial_resolution_m", SpatialResolutionM);
            writer.WriteDateTimeOffsetValue("start_time", StartTime);
            writer.WriteStringValue("title", Title);
            writer.WriteStringValue("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
