using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ODC.MdSharp;
using Polly.Extensions.Http;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODC.MdSharp.RequestModels.GlobalExpressEntry;
using static ODC.MdSharp.RequestModels.GlobalExpressEntry.ExpressRequest.GlobalRequestAddressModel;
using System.Net.Http.Json;
using ODC.MdSharp.Types.GlobalExpressEntry.Global;
using ODC.MdSharp.Types.GlobalExpressEntry;

namespace ODC.MdSharpTests
{

    public class MdClientTests
    {
        readonly MdClientService mdClientService;

        public MdClientTests()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("testsettings.json")
            .Build();

            var services = new ServiceCollection();

            services.AddHttpClient("ExpressEntry", client =>
            {
                client.BaseAddress = new Uri("https://expressentry.melissadata.net/web/");
            }).AddPolicyHandler(GetRetryPolicy());

            services.AddScoped(provider => new MdClientService(clientFactory: provider.GetRequiredService<IHttpClientFactory>(), id: configuration["AppSettings:ApiKey"]!, typedClient: "ExpressEntry", CancellationToken.None));

            var sp = services.BuildServiceProvider();

            mdClientService = sp.GetRequiredService<MdClientService>();
        }
        /// <summary>
        /// Example Policy, this policy enables enough time to have a connection cut off
        /// </summary>
        /// <returns></returns>
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }


        [Fact]
        public async Task Test_EE_GlobalAddressResponses()
        {
            string[] queries = { "kal", "mül", "mülh", "Kal", "Kalker" };

            ExpressRequest.GlobalRequestAddressModel requestModel = new("de", ValidFormats.JSON, queries[0]) { Locality = "Köln", PostalCode = "51103" };

            HttpResponseMessage response = await mdClientService.GET_GlobalExpressAddress(requestModel);

            Assert.True(response.IsSuccessStatusCode);

            //var m = response.Content.ReadFromJsonAsync<ExpressRootRecord<GlobalExpressAddressRecord>>().Result;

            //m.Results.ForEach(x => { Debug.WriteLine(x.AddressSuggestion.Address1); });
        }
    }
}
