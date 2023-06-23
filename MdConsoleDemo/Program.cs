using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ODC.MdSharp;
using Polly.Extensions.Http;
using Polly;
using ODC.MdSharp.RequestModels.GlobalExpressEntry;
using System.Diagnostics;

namespace MdConsoleDemo
{
    internal class Program
    {
        static async Task Main()
        {
            //1Configure
            MdClientService _clientService;
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            var mdClientServiceCollection = new ServiceCollection();
            // Adding Polly to handle exceptions
            mdClientServiceCollection.AddHttpClient("Global", client => { }).AddPolicyHandler(GetRetryPolicy());

            // Singleton because it is a simple console demo app, no user input or any fancy stuff - consider changing depending your scenario
            mdClientServiceCollection.AddSingleton(provider => new MdClientService(provider.GetRequiredService<IHttpClientFactory>(), configuration["x:ApiKeyError"]!, CancellationToken.None));

            //2. Build and Inject Service
            var mdClientServiceProvider = mdClientServiceCollection.BuildServiceProvider();
            _clientService = mdClientServiceProvider.GetRequiredService<MdClientService>();

            //3. build query
            var globalExpressRequestModel = new ExpressRequest.GlobalRequestAddressModel("DE", ExpressRequest.GlobalRequestAddressModel.ValidFormats.JSON, "Haupt") { Locality = "Berlin" };
            //send
            var firstResult = await _clientService.GET_GlobalExpressAddress(globalExpressRequestModel);
            //display
            if (firstResult != null && firstResult.ResultCode == "GE05")
            {
                Console.WriteLine(firstResult);
            }

        }
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

    }
}