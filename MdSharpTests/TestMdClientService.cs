using System.Text.Json;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Extensions.Http;
using ODC.MdSharp;
using ODC.MdSharp.Types.GlobalExpressEntry.Global;
using ODC.MdSharp.RequestModels.GlobalExpressEntry;

namespace MdSharpTests
{
    public class TestMdClientService
    {
        readonly MdClientService mdClientService;
        public TestMdClientService()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var services = new ServiceCollection();

            services.AddHttpClient("Global", client =>
            {
                client.BaseAddress = new Uri("https://expressentry.melissadata.net/web/");
            }).AddPolicyHandler(GetRetryPolicy());

            services.AddScoped(provider => new MdClientService(provider.GetRequiredService<IHttpClientFactory>(), configuration["AppSettings:ApiKey"]!, CancellationToken.None));

            var sp = services.BuildServiceProvider();

            mdClientService = sp.GetRequiredService<MdClientService>();
        }
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
        [Fact]
        public Task TestNewGlobalExpressResponseRecord()
        {
            List<GlobalExpressResponse> responses = new();
            for (int i = 0; i < 100; i++)
            {
                var response = JsonSerializer.Deserialize<GlobalExpressResponse>(DummyData.DummyGlobalExpress.dummyGlobalAddressResponseJson);
                if (i % 10 == 0)
                {
                    responses.Add(response!);
                }
            }
            Assert.NotNull(responses[new Random().Next(0, responses.Count)].Results);
            return Task.CompletedTask;
        }

        [Fact]
        public async Task TestGlobalExpressAddressCall()
        {
            string[] queries = { "feld" };


            for (int i = 0; i < queries.Length; i++)
            {
                ExpressRequest.GlobalRequestAddressModel requestGlobalAddress = new(country: MdClientService.CountryISO2.DE, format: ExpressRequest.GlobalRequestAddressModel.ValidFormats.JSON, queries[0])
                {
                    Locality = "Köln",
                    PostalCode = "51103",
                };
                var e = await mdClientService.GET_GlobalExpressAddress(requestGlobalAddress);
                Assert.True(ResolveExpressEntryResultCode(e.ResultCode));
            }
        }
        [Fact]
        public async Task TestGlobalExpressAddressFreeFormCall()
        {
            string[] queries = { "feld" };


            for (int i = 0; i < queries.Length; i++)
            {
                ExpressRequest.GlobalRequestAddressFreeFormModel requestGlobalAddress = new(country: MdClientService.CountryISO2.DE, format: ExpressRequest.GlobalRequestAddressFreeFormModel.ValidFormats.JSON, queries[0])
                {
                    Locality = "Köln",
                    PostalCode = "51103",
                };
                var e = await mdClientService.GET_GlobalExpressAddressFreeForm(requestGlobalAddress);
                Assert.True(ResolveExpressEntryResultCode(e.ResultCode));
            }
        }
        [Fact]
        public async Task TestGlobalExpressLocalityAdministrativeArea()
        {
            string[] queries = { "feld" };

            for (int i = 0; i < queries.Length; i++)
            {
                ExpressRequest.GlobalRequestLocalityAdministrativeArea requestGlobalAddress = new(ExpressRequest.GlobalRequestLocalityAdministrativeArea.ValidFormats.JSON, "Köln") { };

                var e = await mdClientService.GET_GlobalExpressLocalityAdministrativeArea(requestGlobalAddress);
                Assert.True(ResolveExpressEntryResultCode(e.ResultCode));
            }

        }
        [Fact]
        public async Task TestGlobalExpressPostalCode()
        {
            string[] queries = { "51" };

            for (int i = 0; i < queries.Length; i++)
            {
                ExpressRequest.GlobalRequestPostalCode requestGlobalAddress = new(format: ExpressRequest.GlobalRequestPostalCode.ValidFormats.JSON, postalCode: queries[0], country: MdClientService.CountryISO2.DE) { };

                var e = await mdClientService.GET_GlobalExpressPostalCode(requestGlobalAddress);

                Assert.True(ResolveExpressEntryResultCode(e.ResultCode));
            }

        }
        [Fact]
        public async Task TestGlobalExpressThoroughfare()
        {
            string[] queries = { "Ka" };

            for (int i = 0; i < queries.Length; i++)
            {
                ExpressRequest.GlobalRequestThoroughfare requestGlobalAddress = new(format: ExpressRequest.GlobalRequestThoroughfare.ValidFormats.JSON, thoroughfare: queries[0], country: MdClientService.CountryISO2.DE)
                {
                    PostalCode = "51"
                };

                var e = await mdClientService.GET_GlobalExpressThoroughfare(requestGlobalAddress);

                Assert.True(ResolveExpressEntryResultCode(e.ResultCode));
            }

        }
        private static bool ResolveExpressEntryResultCode(string resultCode)
        {

            if (resultCode is null) return false;

            switch (resultCode)
            {
                case "GE05":
                    Debug.WriteLine(resultCode); return true;
                case "XS01":
                    /*DO SOMETHING*/
                    return true;
                case "XS02":
                    /*DO SOMETHING ELSE*/
                    return true;
                case "XS03":
                    /*DO SOMETHING DIFFERENT*/
                    return true;
                default:
                    return false; // TODO: Result Code coverage 
            }
        }

    }
}