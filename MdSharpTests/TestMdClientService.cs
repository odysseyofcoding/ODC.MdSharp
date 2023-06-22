using Microsoft.Extensions.DependencyInjection;
using ODC.MdSharp;
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using ODC.MdSharp.Types.GlobalExpressEntry.Global;
using ODC.MdSharp.Types.GlobalExpressEntry;
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

            services.AddHttpClient("expressEntry", client =>
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
        public async Task TestGlobalExpressAddressCall()
        {
            string[] queries = { "feld", "mülh", "mant", "loe", "Kalker" };

            List<ExpressRootRecord<GlobalExpressAddressRecord>> records = new();

            for (int i = 0; i < queries.Length; i++)
            {
                ExpressRequest.GlobalRequestAddressModel requestGlobalAddress = new(country: "de", ExpressRequest.GlobalRequestAddressModel.ValidFormats.JSON, searchTerm: queries[i])
                {
                    Locality = "Köln",
                    PostalCode = "51103",
                };

                var e = await mdClientService.GET_GlobalExpressAddress(requestGlobalAddress);

                if (e != null)
                {
                    records.Add(e);

                    Debug.WriteLine(e.ResultCode);
                }
                else
                {
                    Debug.WriteLine("Something went wrong, even with polly");
                }


            }

            Assert.True(true);

            //records.ForEach(rec =>
            //{
            //    rec.Results.ToList().ForEach(rec =>
            //    {
            //        File.AppendAllText("../../TestOutput0.txt", JsonSerializer.Serialize(rec, typeof(GlobalExpressAddressRecord), new JsonSerializerOptions() { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }) + Environment.NewLine);
            //    });
            //});
        }
    }
}