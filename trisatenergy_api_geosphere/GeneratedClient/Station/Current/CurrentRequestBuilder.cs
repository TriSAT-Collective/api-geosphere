// <auto-generated/>
#pragma warning disable CS0618
using ApiSdk.Station.Current.Item;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
namespace ApiSdk.Station.Current
{
    /// <summary>
    /// Builds and executes requests for operations under \station\current
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class CurrentRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the ApiSdk.station.current.item collection</summary>
        /// <param name="position">ID of dataset</param>
        /// <returns>A <see cref="global::ApiSdk.Station.Current.Item.WithResource_ItemRequestBuilder"/></returns>
        public global::ApiSdk.Station.Current.Item.WithResource_ItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("resource_id", position);
                return new global::ApiSdk.Station.Current.Item.WithResource_ItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Station.Current.CurrentRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CurrentRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/station/current", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::ApiSdk.Station.Current.CurrentRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public CurrentRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/station/current", rawUrl)
        {
        }
    }
}
#pragma warning restore CS0618
