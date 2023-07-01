using Microsoft.Extensions.DependencyInjection;
using ODC.MdSharp;
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using ODC.MdSharp.Types.GlobalExpressEntry.Global;
using ODC.MdSharp.RequestModels.GlobalExpressEntry;
using System.Text.Json;
using Xunit;

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

            var result = JsonSerializer.Deserialize<GlobalExpressResponse>(DummyData.DummyGlobalExpress.dummyGlobalAddressResponseJson);
            if (result is not null)
            {
                Assert.NotNull(result.Results);
            }
            else { Assert.False(false); }
            return Task.CompletedTask;
        }

        [Fact]
        public async Task TestGlobalExpressAddressCall()
        {
            string[] queries = { "feld", "mülh", "mant", "loe", "Kalker" };


            for (int i = 0; i < queries.Length; i++)
            {
                ExpressRequest.GlobalRequestAddressModel requestGlobalAddress = new(country: MdClientService.CountryISO2.DE, ExpressRequest.GlobalRequestAddressModel.ValidFormats.JSON, searchTerm: queries[i])
                {
                    Locality = "Köln",
                    PostalCode = "51103",
                };

                var e = await mdClientService.GET_GlobalExpressAddress(requestGlobalAddress);
                Assert.True(ResolveResultCode(e.ResultCode));
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
                Assert.True(ResolveResultCode(e.ResultCode));
            }


            //records.ForEach(rec =>
            //{
            //    rec.Results.ToList().ForEach(rec =>
            //    {
            //        File.AppendAllText("../../TestOutput0.txt", JsonSerializer.Serialize(rec, typeof(GlobalExpressAddressRecord), new JsonSerializerOptions() { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }) + Environment.NewLine);
            //    });
            //});
        }

        private static bool ResolveResultCode(string resultCode)
        {
            if (resultCode != null)
            {
                switch (resultCode)
                {
                    case "GE05":
                        Debug.WriteLine(resultCode); return true;
                    case "XS01":
                        /*DO SOMETHING DIFFERENT*/
                        return true;
                    case "XS02":
                        /*DO SOMETHING DIFFERENT*/
                        return true;
                    case "XS03":
                        /*DO SOMETHING DIFFERENT*/
                        return true;
                    default:
                        return false; // TODO: Result Code coverage 
                }
            }
            return false;
        }

    }
}