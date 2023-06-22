using ODC.MdSharp.RequestModels.GlobalExpressEntry;
using System.Reflection;
using System.Text;


namespace ODC.MdSharp
{
    /// <summary>
    /// 
    /// </summary>
    public class MdClientService : IDisposable
    {
        private readonly string id = string.Empty;
        private readonly HttpClient client;
        private readonly CancellationTokenSource cts;
        private const string Delimiter = "&{0}={1}";
        private readonly StringBuilder str = new();
        /// <summary>
        /// ToDo: Research for a web resource to fetch up to date URIs
        /// </summary>
        public MdClientService(IHttpClientFactory clientFactory, string id, string typedClient, CancellationToken ctx)
        {
            this.client = clientFactory.CreateClient(typedClient);
            this.cts = CancellationTokenSource.CreateLinkedTokenSource(ctx);
            this.id = id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GET_GlobalExpressAddress(ExpressRequest.GlobalRequestAddressModel requestModel)
        {
            HttpResponseMessage responseMessage;

            string query = BuildRequestQuery(ExpressRequest.Endpoints.Global.GlobalExpressAddress, requestModel);

            try
            {
                responseMessage = await client.GetAsync(query, HttpCompletionOption.ResponseHeadersRead, CancellationToken.None);
            }
            catch (Exception ex)
            {
                //Http Exceptions are handled by Polly
                //Debug, bad registration of service could lead to exception or outdated URIs. Considering to use additional service to keep baseURI up to date and health checks
                throw new Exception(ex.Message);
            }
            return responseMessage;
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
            //TODO: add interfaces for request models
            try
            {
                searchTerm = properties.Where(p => p.Name == "SearchTerm").First().GetValue(requestModel)!.ToString()!;
                str.Append("&address1=" + searchTerm);
                var liftedList = properties.Where(x => x.Name != "SearchTerm" && x.Name != "Format");
                props = liftedList.ToList();
            }
            catch (Exception)
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
