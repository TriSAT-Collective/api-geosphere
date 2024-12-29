// <auto-generated/>
#pragma warning disable CS0618
using ApiSdk.Timeseries.Historical.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace ApiSdk.Timeseries.Historical
{
    /// <summary>
    /// Builds and executes requests for operations under \timeseries\historical
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class HistoricalRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the ApiSdk.timeseries.historical.item collection</summary>
        /// <param name="position">ID of dataset</param>
        /// <returns>A <see cref="global::ApiSdk.Timeseries.Historical.Item.WithResource_ItemRequestBuilder"/></returns>
        public global::ApiSdk.Timeseries.Historical.Item.WithResource_ItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("resource_id", position);
                return new global::ApiSdk.Timeseries.Historical.Item.WithResource_ItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Timeseries.Historical.HistoricalRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public HistoricalRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/timeseries/historical", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Timeseries.Historical.HistoricalRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public HistoricalRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/timeseries/historical", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
