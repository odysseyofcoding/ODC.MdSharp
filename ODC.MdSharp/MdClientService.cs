using ODC.MdSharp.RequestModels.GlobalExpressEntry;
using ODC.MdSharp.Types.GlobalExpressEntry;
using ODC.MdSharp.Types.GlobalExpressEntry.Global;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;


namespace ODC.MdSharp
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MdClientService : IDisposable
    {
        private readonly string id = string.Empty;
        private readonly HttpClient client;
        private readonly CancellationTokenSource cts;
        private const string Delimiter = "&{0}={1}";
        private readonly StringBuilder str = new();
        /// <summary>
        /// ToDo: Add description
        /// </summary>
        public MdClientService(IHttpClientFactory clientFactory, string id, CancellationToken ctx)
        {
            this.client = clientFactory.CreateClient("Global");
            client.BaseAddress = new Uri("https://expressentry.melissadata.net/web/");
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));
            this.cts = CancellationTokenSource.CreateLinkedTokenSource(ctx);
            this.id = id;
        }
        /// <summary/>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<GlobalExpressResponse> GET_GlobalExpressAddress(ExpressRequest.GlobalRequestAddressModel requestModel)
        {

            string requestURI = BuildRequestQuery(MdEnpoints.GlobalCloudServices.ExpressEntry.Global.Address, requestModel);

            using HttpResponseMessage responseMessage = await client.GetAsync(requestURI, cts.Token);

            responseMessage.EnsureSuccessStatusCode();

            // if Format == XML or JSON => ToDo:
            var result = await responseMessage.Content.ReadFromJsonAsync<GlobalExpressResponse>();

            return result is not null ? result : throw new NotImplementedException("alpha version - please check type of exception");
        }
        /// <summary/>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<GlobalExpressResponse> GET_GlobalExpressAddressFreeForm(ExpressRequest.GlobalRequestAddressFreeFormModel requestModel)
        {

            string requestURI = BuildRequestQuery(MdEnpoints.GlobalCloudServices.ExpressEntry.Global.FreeForm, requestModel);

            using HttpResponseMessage responseMessage = await client.GetAsync(requestURI, cts.Token);

            responseMessage.EnsureSuccessStatusCode();

            // if Format == XML or JSON => ToDo:
            var result = await responseMessage.Content.ReadFromJsonAsync<GlobalExpressResponse>();

            return result is not null ? result : throw new NotImplementedException("alpha version - please check type of exception");
        }
        /// <summary/>
        public async Task<GlobalExpressResponse> GET_GlobalExpressLocalityAdministrativeArea(ExpressRequest.GlobalRequestLocalityAdministrativeArea requestModel)
        {
            string requestURI = BuildRequestQuery(MdEnpoints.GlobalCloudServices.ExpressEntry.Global.LocalityAdministrativeArea, requestModel);
            using HttpResponseMessage responseMessage = await client.GetAsync(requestURI, cts.Token);
            responseMessage.EnsureSuccessStatusCode();
            var result = await responseMessage.Content.ReadFromJsonAsync<GlobalExpressResponse>();
            return result is not null ? result : throw new NotImplementedException("alpha version - please check type of exception");

        }
        /// <summary/>
        public async Task<GlobalExpressResponse> GET_GlobalExpressPostalCode(ExpressRequest.GlobalRequestPostalCode requestModel)
        {
            string requestURI = BuildRequestQuery(MdEnpoints.GlobalCloudServices.ExpressEntry.Global.PostalCode, requestModel);
            using HttpResponseMessage responseMessage = await client.GetAsync(requestURI, cts.Token);
            responseMessage.EnsureSuccessStatusCode();
            var result = await responseMessage.Content.ReadFromJsonAsync<GlobalExpressResponse>();
            return result is not null ? result : throw new NotImplementedException("alpha version - please check type of exception");
        }
        /// <summary/>
        public async Task<GlobalExpressResponse> GET_GlobalExpressThoroughfare(ExpressRequest.GlobalRequestThoroughfare requestModel)
        {
            string requestURI = BuildRequestQuery(MdEnpoints.GlobalCloudServices.ExpressEntry.Global.Thoroughfare, requestModel);
            using HttpResponseMessage responseMessage = await client.GetAsync(requestURI, cts.Token);
            responseMessage.EnsureSuccessStatusCode();
            var result = await responseMessage.Content.ReadFromJsonAsync<GlobalExpressResponse>();
            return result is not null ? result : throw new NotImplementedException("alpha version - please check type of exception");
        }
        /// <summary>
        /// Maybe static
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        private string BuildRequestQuery<T>(string endpoint, T requestModel)
        {
            str.Append(endpoint + '?');

            Type type = requestModel!.GetType();

            PropertyInfo[] properties = type.GetProperties();

            var format = properties.Where(p => p.Name == "Format").First().GetValue(requestModel);

            string? searchTerm = string.Empty;

            str.Append("format=" + format);
            str.Append("&id=" + id);

            List<PropertyInfo> props = new();
            if (requestModel is IRequestExpressFreeForm)
            {
                searchTerm = properties.Where(p => p.Name == "SearchTerm").First().GetValue(requestModel)!.ToString()!;
                str.Append("&ff=" + searchTerm);
                var liftedList = properties.Where(x => x.Name != "SearchTerm" && x.Name != "Format");
                props = liftedList.ToList();
            }
            else
            {
                props = properties.Where(y => y.Name != "Format").ToList();
            }

            props.ToList().ForEach(property =>
            {
                var propertyValue = property.GetValue(requestModel)?.ToString();

                if (propertyValue is not null)
                {
                    _ = str.AppendFormat(Delimiter, property.Name.ToLower(), propertyValue.ToLower());
                }
            });
            Debug.WriteLine(str.ToString());
            return str.ToString();
        }
        void IDisposable.Dispose()
        {
            cts.Cancel();
            client.CancelPendingRequests();
            GC.SuppressFinalize(this);
        }
    }
}
