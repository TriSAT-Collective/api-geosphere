// <auto-generated/>
#pragma warning disable CS0618
using ApiSdk.Station.Item.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace ApiSdk.Station.Item
{
    /// <summary>
    /// Builds and executes requests for operations under \station\{mode}
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class WithModeItemRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the ApiSdk.station.item.item collection</summary>
        /// <param name="position">ID of dataset</param>
        /// <returns>A <see cref="global::ApiSdk.Station.Item.Item.WithResource_ItemRequestBuilder"/></returns>
        public global::ApiSdk.Station.Item.Item.WithResource_ItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("resource_id", position);
                return new global::ApiSdk.Station.Item.Item.WithResource_ItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Station.Item.WithModeItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithModeItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/station/{mode}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Station.Item.WithModeItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public WithModeItemRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/station/{mode}", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618