using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ODC.MdSharp;
using Polly.Extensions.Http;
using Polly;
using ODC.MdSharp.RequestModels.GlobalExpressEntry;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace MdConsoleDemo
{
    internal class Program
    {
        static async Task Main()
        {
            // Configure
            MdClientService _clientService;
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            var mdClientServiceCollection = new ServiceCollection();

            //ReadAsStringAsync should adapt utf-8 for encoding with this assignment - not testet
            mdClientServiceCollection.AddHttpClient("Global", client =>
            {
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));
                // Adding Polly to handle exceptions
            }).AddPolicyHandler(GetRetryPolicy());

            // Singleton because it is a simple console demo app, no user input or any fancy stuff - consider changing depending your scenario
            mdClientServiceCollection.AddSingleton(provider => new MdClientService(provider.GetRequiredService<IHttpClientFactory>(), configuration["x:ApiKeyError"]!, CancellationToken.None));

            // Build and Inject Service
            var mdClientServiceProvider = mdClientServiceCollection.BuildServiceProvider();
            _clientService = mdClientServiceProvider.GetRequiredService<MdClientService>();

            //3. build query
            var globalExpressRequestModel = new ExpressRequest.GlobalRequestAddressModel(MdClientService.CountryISO2.DE, ExpressRequest.GlobalRequestAddressModel.ValidFormats.JSON, "Haupt") { Locality = "Berlin" };
            //send
            var firstResult = await _clientService.GET_GlobalExpressAddress(globalExpressRequestModel);

            if (firstResult is not null)
            {
                switch (firstResult.ResultCode)
                {
                    case "GE05": Debug.WriteLine(firstResult); break;
                    case "XS01": /*DO SOMETHING*/; break;
                    case "XS02": /*DO SOMETHING DIFFERENT*/; break;
                    case "XS03": /*DO SOMETHING DIFFERENT*/; break;
                    default: throw new NotImplementedException("No ResultCode catched"); // TODO: Result Code coverage 
                }
            }

        }
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(4, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

    }
}